import { Component, OnInit, ViewChild, EventEmitter, Input } from '@angular/core';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { merge } from 'rxjs';
import { UowService } from 'src/app/services/uow.service';
import { Responsable, Mesure, Organisme } from 'src/app/Models/models';
import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';
import { DeleteService } from '../../components/delete/delete.service';
import { UpdateComponent } from '../../user/update/update.component';

@Component({
  selector: 'app-responsables',
  templateUrl: './responsables.component.html',
  styleUrls: ['./responsables.component.scss']
})
export class ResponsablesComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @Input() mesure = new Mesure();
  update = new EventEmitter();

  isLoadingResults = true;
  resultsLength = 0;
  isRateLimitReached = false;

  selectedList: Organisme[] = [];
  todeleteList: Responsable[] = [];
  useFullList: Responsable[] = [];
  myForm: FormGroup;
  o = new Responsable();
  isEdit = false;
  organismes = this.uow.organismes.get();
  users = [];
  dataSource = [];
  columnDefs = [
    { columnDef: 'nom', headName: 'القطاع' },
    { columnDef: 'duree', headName: 'المخاطب الرسمي' },
    { columnDef: 'option', headName: 'OPTION' },
  ];

  // toppings = new FormControl();

  toppingList = [...Array(15).keys()].map(e => `${2016 + e}`);

  displayedColumns = this.columnDefs.map(e => e.columnDef);

  constructor(private uow: UowService, public dialog: MatDialog
    , private mydialog: DeleteService, private fb: FormBuilder) { }

  ngOnInit() {
    //Object.assign(new Responsable(), this.o).dureeToArray();
    this.createForm();
    this.getPage(0, 10, 'id', 'desc');
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
        );
      }
    );
  }

  getPage(startIndex, pageSize, sortBy, sortDir) {
    this.isLoadingResults = true;
    this.uow.organismes.getList(startIndex, pageSize, sortBy, sortDir).subscribe(
      (r: any) => {
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.isLoadingResults = false;


     }
    );

  }

  createForm() {
    // this.o.duree = this.o.dureeToString();
    this.myForm = this.fb.group({
      idOrganisme: [this.o.idOrganisme],
      idMesure: [this.mesure.id],
    });
  }

  submit2(o: Responsable) {
    // console.log(o);
    if (!this.isEdit) {
      this.uow.responsables.post(o).subscribe(r => {
        this.reset();
        this.update.next(true);
      });
    } else {
      this.uow.responsables.put(o.idMesure, o).subscribe(r => {
        this.reset();
        this.update.next(true);
      });
    }
  }

  submit() {
    this.useFullList = [];
    this.selectedList.map(r => {
      this.useFullList.push({ idOrganisme: r.id, idMesure: this.mesure.id } as any);
    });
    // console.log('listRecommendation', this.selectedList, 'this.o.recommendations', this.o.recommendations)
    // console.log(this.todeleteList, this.useFullList);
    this.uow.responsables.putRange(this.todeleteList, this.useFullList).subscribe(e => {
      // this.navTab.navigateTo.next(2);
      this.todeleteList = this.useFullList;
    });
  }



  edit(o: Responsable) {
    this.o = o;
    // Object.assign(new Activite(), this.o).dureeToArray()
    this.isEdit = true;
    this.createForm();
  }

  reset() {
    this.o = new Responsable();
    // this.o = this.o.dureeToArray();
    this.isEdit = false;
    this.createForm();
  }

  async delete(id: number) {
    const r = await this.mydialog.openDialog('Mesure').toPromise();
    if (r === 'ok') {
      this.uow.responsables.delete(id).subscribe(() => {
        this.update.next(true);
      });
    }
  }

}


