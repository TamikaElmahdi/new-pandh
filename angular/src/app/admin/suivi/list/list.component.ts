import { Mesure } from '../../../Models/models';
import { Component, OnInit, ViewChild, EventEmitter } from '@angular/core';
import { MatPaginator, MatSort, MatDialog, MatAutocompleteSelectedEvent, MatInput } from '@angular/material';
import { merge, Observable } from 'rxjs';
import { UowService } from 'src/app/services/uow.service';
import { SnackbarService } from 'src/app/shared/snakebar.service';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router, NavigationStart } from '@angular/router';
import { SessionService } from 'src/app/shared';
import { switchMap, map } from 'rxjs/operators';
import { DetailsComponent } from '../details/details.component';
import { DeleteService } from '../../components/delete/delete.service';
import { ManagePermissionService } from 'src/app/shared/manage.permission.service';
import { ExcelService } from 'src/app/shared/excel.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  // @ViewChild('myAutocomplete', { static: true }) myAutocomplete: MatInput;
  update = new EventEmitter();
  isLoadingResults = true;
  resultsLength = 0;
  isRateLimitReached = false;
  dataSource = [];
  // periodes = [2019, 2020, 2021, 2022, 2023];
  // planifications = ['1المخطط', '1المخطط', '1المخطط', '1المخطط', '1المخطط', '1المخطط',];
  // responsables = ['المخاطب الرسمي1', 'المخاطب الرسمي1', 'المخاطب الرسمي1', 'المخاطب الرسمي1', 'المخاطب الرسمي1', 'المخاطب الرسمي1',];
  situations = ['في طور الإنجاز', 'عمل متواصل', 'منجز', 'غير منجز']

  columnDefs = [
    // { columnDef: 'cycle', headName: 'المرحلة' },
    { columnDef: 'mesure', headName: 'التدبير' },
    // { columnDef: 'activite', headName: 'النشاط' },
    // { columnDef: 'annee', headName: 'السنة' },
    // { columnDef: 'nom', headName: 'الإنجاز' },
    // { columnDef: 'situation', headName: 'وضعية التنفيد' },
    { columnDef: 'realisations', headName: '' },
    { columnDef: 'tauxTotal', headName: 'معدل الإنجاز الإجمالي' },
    // { columnDef: 'option', headName: '' },
  ].map(e => {
    e.headName = e.headName === '' ? e.columnDef.toUpperCase() : e.headName;
    return e;
  });
  //
  panelOpenState = false;
  //
  organismes = [];
  typeMesures = [
    { id: 1, value: 'المخطط التنفيدي' },
    { id: 2, value: 'المخطط التنفيدي الترابي' },
    { id: 3, value: 'برامج العمل' }
  ];
  mesures = [];
  axes = this.uow.axes.get();
  sousAxes = [];
  cycles = this.uow.cycles.get();
  users = this.uow.users.get();

  myForm: FormGroup;
  //
  displayedColumns = this.columnDefs.map(e => e.columnDef);
  // progress = 0;
  // message: any;
  // formData = new FormData();
  o = new Model();
  myAuto = new FormControl('');
  filteredOptions: Observable<any>;
  //
  isMesureRegion = false;
  isMesure = false;
  isProgramme = false;
  typeOrganisme = 1;
  //
  routeMesure = '';
  //
  // regions = ['الرباط', 'تمارة'];
  // oranismes = ['الجامعة', 'الأكاديمية', 'محو الأمية'];
  title = '';
  constructor(public uow: UowService, private mydialog: DeleteService
    , private snack: SnackbarService, private fb: FormBuilder
    , public session: SessionService, public dialog: MatDialog
    , public per: ManagePermissionService, public router: Router, private excel: ExcelService) { }

  ngOnInit() {
    // this.routeMesure = this.router.url;
    // this.checkWitchMesure(this.routeMesure);
    // this.o.typeOrganisme = this.typeOrganisme;
    this.searchAndGet(this.o);
    // console.warn('>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>')
    this.createForm();

    // this.router.events.subscribe(route => {
    //   if (route instanceof NavigationStart) {
    //     this.routeMesure = route.url;
    //     // console.log(this.routeMesure);
    //     this.checkWitchMesure(this.routeMesure);
    //     this.o.typeOrganisme = this.typeOrganisme;
    //     this.createForm();
    //     this.update.next(true);
    //     console.warn('>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>')
    //   }
    // });


    merge(...[this.sort.sortChange, this.paginator.page, this.update]).subscribe(
      r => {
        r === true ? this.paginator.pageIndex = 0 : r = r;
        !this.paginator.pageSize ? this.paginator.pageSize = 10 : r = r;
        // this.o = new Model();
        this.o.startIndex = this.paginator.pageIndex * this.paginator.pageSize;
        this.o.pageSize = this.paginator.pageSize;
        this.o.sortBy = this.sort.active ? this.sort.active : 'id';
        this.o.sortDir = this.sort.direction ? this.sort.direction : 'desc';
        this.isLoadingResults = true;
        this.searchAndGet(this.o);
      }
    );

    // this.route.queryParams.subscribe(params => {
    //   const id = params['data'];
    //   if (id) {
    //     this.uow.mesures.getOne(id).subscribe(r => {
    //       // this.openDialog(r);
    //     });
    //   }
    // });

    // this.getRoute();
    this.autoComplete();
  }

  navToUpdate(id = 0) {
    // console.log(`${this.routeMesure.replace('/list', '')}/update`, 0)
    this.router.navigate([`${this.routeMesure.replace('/list', '')}/update`, id]);
  }

  selectChange2(idMesure) {
    console.log(idMesure);
    if (idMesure === 2) {
      this.isMesureRegion = true;
      this.isMesure = false;
      this.isProgramme = false;
      this.typeOrganisme = 2;
      this.getOrganismes();
    } else if (idMesure === 3) {
      this.isMesureRegion = false;
      this.isMesure = false;
      this.isProgramme = true;
      this.typeOrganisme = 3;
      this.getOrganismes();
    } else {
      this.isMesureRegion = false;
      this.isMesure = true;
      this.isProgramme = false;
      this.typeOrganisme = 1;
      this.getOrganismes();
    }
  }

  getOrganismes() {
    this.uow.organismes.getByType(this.typeOrganisme).subscribe(r => {
      console.log(r);
      this.organismes = r as any;
    });
  }

  exportExcel() {
    const l = this.dataSource.map(s => {
      return {
        القطاع: s.count,
        // التدبير: s.mesure,
        // 'الأنشطة المنجزة': s.activite,
        // السنة: s.annee,
        // 'حصيلة التنفيد': s.situation,
        // 'معدل الإنجاز': s.taux,
        // وضعية: s.effet,
      };
    });
    // console.log(l);
    // console.log(Object.values(this.dataSource));
    this.excel.exportAsExcelFile(l, 'sample');
  }

  autoComplete() {
    this.filteredOptions = this.myAuto.valueChanges.pipe(
      // startWith(''),
      switchMap((value: string) => value.length > 1 ? this.uow.organismes.autocomplete('label', value) : []),
      // map(r => r)
    );
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    const o = event.option.value as any;
    console.log(o);
    this.myAuto.setValue(o.label);
    (this.myForm.get('idOrganisme') as FormControl).setValue(o.id);
  }

  createForm() {
    this.myForm = this.fb.group({
      idCycle: this.o.idCycle,
      idMesure: this.o.idMesure,
      idResponsable: this.o.idResponsable,
      idOrganisme: this.o.idOrganisme,
      typeOrganisme: this.o.typeOrganisme,
      idAxe: this.o.idAxe,
      idSousAxe: this.o.idCycle,
      codeMesure: this.o.codeMesure,
      nomMesure: this.o.nomMesure,
      situation: this.o.situation,
      startIndex: this.o.startIndex,
      pageSize: this.o.pageSize,
      sortBy: this.o.sortBy,
      sortDir: this.o.sortDir,
    });
  }

  selectChange(id, name) {
    if (name === 'axe') {
      this.uow.sousAxes.getByIdAxe(id).subscribe(r => {
        this.sousAxes = r as any[];
      });
    } else if (name === 'cycle') {
      this.uow.mesures.getByForeignKey(id).subscribe(r => {
        this.mesures = r as any[];
      });

    }
  }

  reset() {
    this.o = new Model();
    this.createForm();
    this.searchAndGet(this.o);
  }

  search(o: Model) {
    // this.searchAndGet(o);
    this.o = o;
    // console.log(this.o)
    this.update.next(true);
  }

  detail(o) {
    this.uow.realisations.getOneWithInclude(o.id).subscribe(r => {
      this.openDialog(r);
    });
  }

  openDialog(o: any) {
    const dialogRef = this.dialog.open(DetailsComponent, {
      width: '7100px',
      disableClose: true,
      data: { model: o, title: 'تتبع' },
      direction: 'rtl',
    });

    return dialogRef.afterClosed();
  }

  searchAndGet(o: Model) {
    console.log(o);
    this.o = o;
    // this.o.idOrganisme = this.session.isPointFocal || this.session.isProprietaire ? this.session.user.idOrganisme : this.o.idOrganisme;
    this.uow.realisations.searchAndGet(this.o).subscribe(
      (r: any) => {
        console.log(r.list);
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.isLoadingResults = false;
      }, e => this.isLoadingResults = false,
    );
  }

  async delete(o: Mesure) {
    const r = await this.mydialog.openDialog('تتبع').toPromise();
    if (r === 'ok') {
      this.uow.realisations.delete(o.id).subscribe(() => this.update.next(true));
    }
  }

  axeChange(idAxe: number) {
    this.uow.sousAxes.getByIdAxe(idAxe).subscribe(r => {
      this.sousAxes = r as any[];
    });
  }

  get isAllEmpty(): boolean {
    if (this.myForm.get('idAxe').value.toString() === '0' &&
      this.myForm.get('idCycle').value.toString() === '0' &&
      this.myForm.get('idSousAxe').value.toString() === '0' &&
      this.myForm.get('idMesure').value.toString() === '0' &&
      this.myForm.get('idOrganisme').value.toString() === '0' &&
      this.myForm.get('idResponsable').value.toString() === '0' &&
      this.myForm.get('codeMesure').value.toString() === '' &&
      this.myForm.get('nomMesure').value.toString() === '' &&
      this.myForm.get('situation').value.toString() === '') {
      return true;
    }
    return false;
  }

}

class Model {
  idCycle = 0;
  idMesure = 0;
  idResponsable = 0;
  idAxe = 0;
  idSousAxe = 0;
  idOrganisme = 0;
  typeOrganisme = 1;
  nomMesure = '';
  codeMesure = '';
  situation = '';
  // mecanisme = '';
  startIndex = 0;
  pageSize = 10;
  sortBy = 'id';
  sortDir = 'desc';
}


