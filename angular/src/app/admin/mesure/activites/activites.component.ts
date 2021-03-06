import { Organisme, Mesure, ActiviteMesure, Activite } from './../../../Models/models';
import { Component, OnInit, ViewChild, EventEmitter, Output, Input } from '@angular/core';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { merge } from 'rxjs';
import { UowService } from 'src/app/services/uow.service';

@Component({
  selector: 'app-activites',
  templateUrl: './activites.component.html',
  styleUrls: ['./activites.component.scss']
})
export class ActivitesComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  // @Output() eventToParent = new EventEmitter<any[]>();

  selectedList: Activite[] = [];
  todeleteList: ActiviteMesure[] = [];

  useFullList: ActiviteMesure[] = [];

  selectedList2 = this.uow.activites.get();
  todeleteList2 = this.uow.activiteMesures.get();
  // listFromParent: Partenariat[] = [];

  isEdit = false;
  update = new EventEmitter();
  isLoadingResults = false;
  resultsLength = 0;
  isRateLimitReached = false;

  @Input() mesure = new Mesure();
  // mecanisme = '';
  // selectInput = new FormControl(0);
  dataSource = [];
  dataFilter = [];
  columnDefs = [
    { columnDef: 'select', headName: '' },
    { columnDef: 'nom', headName: 'إسم' },
    { columnDef: 'duree', headName: 'السنة' },
    // { columnDef: 'adresse', headName: 'عنوان' },
    // { columnDef: 'tel', headName: 'هاتف' },
    // { columnDef: 'option', headName: 'OPTION' },
  ];
  displayedColumns = this.columnDefs.map(e => e.columnDef);
  // selection = new SelectionModel<Partenariat>(true, []);

  constructor(private uow: UowService) { }

  ngOnInit() {


    this.uow.activites.getByForeignKey(this.mesure.id).subscribe(r => {
      this.selectedList = r as any[];
      this.selectedList.forEach(row => {
        this.todeleteList.push({ idActivite: row.id, idMesure: this.mesure.id } as any);
      });
    });

    // this.selectedList = [];

    if (this.mesure.id !== 0) {
      this.isEdit = true;
    }

    this.getPage(0, 10, 'id', 'desc', this.mesure.id);
    merge(...[this.sort.sortChange, this.paginator.page, this.update]).subscribe(
      r => {
        r === true ? this.paginator.pageIndex = 0 : r = r;
        !this.paginator.pageSize ? this.paginator.pageSize = 10 : r = r;
        const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
        this.isLoadingResults = true;
        this.getPage(
          startIndex,
          this.paginator.pageSize,
          this.sort.active ? this.sort.active : 'id',
          this.sort.direction ? this.sort.direction : 'desc',
          this.mesure.id
        );
      }
    );
  }

  getPage(startIndex, pageSize, sortBy, sortDir, id) {
    this.isLoadingResults = true;
    this.uow.activites.getListActivite(startIndex, pageSize, sortBy, sortDir, this.mesure.id).subscribe(
      (r: any) => {
        console.log(r.list);
        this.dataSource = r.list.map(e => {
          //e.duree = Object.assign(new Activite(), e).dureeToArray();
          return e;
        });
        this.resultsLength = r.count;
        this.isLoadingResults = false;
     }
    );
  }

  getDataFiltre(searchText) {
    this.isLoadingResults = true;
    this.uow.activites.getDataFiltre(searchText).subscribe(
      (r: any) => {
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.isLoadingResults = false;
     }
    );
  }




  submit() {
    this.useFullList = [];
    this.selectedList.map(r => {
      this.useFullList.push({ idActivite: r.id, idMesure: this.mesure.id } as any);
    });
    // console.log('listRecommendation', this.selectedList, 'this.o.recommendations', this.o.recommendations)
    // console.log(this.todeleteList, this.useFullList);
    this.uow.activiteMesures.putRange(this.todeleteList, this.useFullList).subscribe(e => {
      // this.navTab.navigateTo.next(2);
      this.todeleteList = this.useFullList;
    });
  }


  isSelected(row): boolean {
    // console.log(this.selectedList)
    // this.selectedList.forEach(e => console.log(+e.id, +row.id))
    // console.log(this.selectedList.find(e => +e.id === +row.id) ? true : false);
    return this.selectedList.find(e => e.id === row.id) ? true : false;
  }

  search(term: string) {
    if (term !== null && term !== '') {
      this.getDataFiltre(term);
    } else {
      this.getPage(0, 10, 'id', 'desc', this.mesure.id);
    }
  }

  check(r) {
    const i = this.selectedList.findIndex(o => r.id === o.id);
    const existe: boolean = i !== -1;
    if (!existe) {
      this.selectedList.push(r);
    } else {
      this.selectedList.splice(i, 1);
    }
    // console.log(this.todeleteList);
    // this.eventToParent.next(this.selectedList);
  }

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selectedList.length;
    const numRows = this.paginator.pageSize;
    // console.log(numSelected, numRows)
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    if (this.isAllSelected()) {
      this.selectedList = [];
    } else {
      this.selectedList = [];
      this.dataSource.forEach(row => this.selectedList.push(row));
    }
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: Activite): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    // return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.id}`;
    return `${this.selectedList.find(e => e.id === row.id) ? 'deselect' : 'select'} row ${row.id}`;
  }

}

