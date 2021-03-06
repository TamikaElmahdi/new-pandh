import { Mesure, Organisme, Responsable } from './../../../Models/models';
import { Component, OnInit, ViewChild, EventEmitter } from '@angular/core';
import { MatPaginator, MatSort, MatDialog, MatAutocompleteSelectedEvent, MatInput } from '@angular/material';
import { BehaviorSubject, merge, Observable, Subject } from 'rxjs';
import { UowService } from 'src/app/services/uow.service';
import { SnackbarService } from 'src/app/shared/snakebar.service';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router, NavigationStart } from '@angular/router';
import { SessionService } from 'src/app/shared';
import { switchMap, map } from 'rxjs/operators';
import { DetailsComponent } from '../details/details.component';
import { DeleteService } from '../../components/delete/delete.service';
import { IData } from '../../components/pie-chart/pie-chart.component';
import { trigger, state, style, transition, animate } from '@angular/animations';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class ListComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  // @ViewChild('myAutocomplete', { static: true }) myAutocomplete: MatInput;

  update = new EventEmitter();
  isLoadingResults = true;
  resultsLength = 0;
  resultsLengthTadabir = 0;
  isRateLimitReached = false;
  dataSource = [];
  expandedElement = new Organisme();



  pieChartSubjectC =  new Subject();
  pieChartSubjectD =  new Subject();
  pieChartSubject_1 =  new Subject();
  pieChartSubject_2 =  new Subject();
  pieChartSubject_3 =  new Subject();
  pieChartSubject_4 =  new Subject();

  dataEpu = new Subject<{ name: string | Observable<string>, p: number, t: number, r: number, n: number }>();

  examenPageSubject = new Subject();
  countRec = new Subject();
  dataEpuPie = new Subject();
  listeAxes = this.uow.axes.get();

  // periodes = [2019, 2020, 2021, 2022, 2023];
  // planifications = ['1المخطط', '1المخطط', '1المخطط', '1المخطط', '1المخطط', '1المخطط',];
  // responsables = ['المخاطب الرسمي1', 'المخاطب الرسمي1', 'المخاطب الرسمي1', 'المخاطب الرسمي1', 'المخاطب الرسمي1', 'المخاطب الرسمي1',];

  columnDefs = [
    { columnDef: 'cycle', headName: 'المرحلة' },
    { columnDef: 'organisme', headName: 'الجهة' },
    //{ columnDef: 'nom', headName: 'التدبير' },
    //{ columnDef: 'responsable', headName: 'المخاطب الرسمي' },
    // { columnDef: 'partenaire', headName: 'الشركاء' },
    // { columnDef: 'activite', headName: 'الأنشطة' },
    //{ columnDef: 'resultatsAttendu', headName: 'النتائج المبرمجة' },
    // { columnDef: 'indicateur', headName: 'مؤشرات القياس' },
    { columnDef: 'option', headName: '' },
  ].map(e => {
    e.headName = e.headName === '' ? e.columnDef.toUpperCase() : e.headName;
    return e;
  });
  //
  panelOpenState = false;
  //
  organismes = [];
  mesures = [];
  axes = this.uow.axes.get();
  sousAxes = [];
  cycles = this.uow.cycles.get();
  users = [];
  //organismeFiltres = this.uow.organismes.getByType(1);
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
  type = 1;
  //
  routeMesure = '';
  //
  regions = ['الرباط', 'تمارة'];
  oranismes = ['الجامعة', 'الأكاديمية', 'محو الأمية'];
  title = '';
  constructor(private uow: UowService, private mydialog: DeleteService
    , private snack: SnackbarService, private fb: FormBuilder
    , public session: SessionService, public dialog: MatDialog
    , private route: ActivatedRoute, public router: Router) { }

  ngOnInit() {

    if (this.router.url.includes('mesure-executif')) {
      this.type = 1;

    } else if (this.router.url.includes('mesure-programme')) {
      this.type = 2;

    } else {
      this.type = 3;
    }

    this.pieChartSubjectC = new BehaviorSubject<IData>({ table: 'axe', type: 'tauxRealisation', typeTable: this.type, title: 'التوزيع حسب المحاور الرئيسية ', idAxe: 0  });

    this.pieChartSubject_1 = new BehaviorSubject<IData>({ table: 'sousAxe', type: 'tauxRealisation', typeTable: this.type, title: 'الحكامة والديمقراطية ' , idAxe:1  });
    this.pieChartSubject_2 = new BehaviorSubject<IData>({ table: 'sousAxe', type: 'tauxRealisation', typeTable: this.type, title: 'الحقوق الاقتصادية والاجتماعية والثقافية والبيئية' , idAxe:2  });
    this.pieChartSubject_3 = new BehaviorSubject<IData>({ table: 'sousAxe', type: 'tauxRealisation', typeTable: this.type, title: 'حماية الحقوق الفئوية والنهوض بها' , idAxe:3  });
    this.pieChartSubject_4 = new BehaviorSubject<IData>({ table: 'sousAxe', type: 'tauxRealisation', typeTable: this.type, title: 'الإطار القانوني والمؤسساتي' , idAxe:4  });


    this.listeAxes.subscribe(r => {
    r.forEach(e => {
    this.pieChartSubjectD = new BehaviorSubject<IData>({ table: 'sousAxe', type: 'tauxRealisation', typeTable: this.type, title: e.label , idAxe:e.id  });

    });
  });


    this.stateAxe();
    this.stateOneOFMecanisme();
    this.getOrganismes();
    this.routeMesure = this.router.url;
    this.checkWitchMesure(this.routeMesure);
    this.o.typeOrganisme = this.typeOrganisme;
    //this.searchAndGet(this.o);
    this.getPage(new Model());

    // console.warn('>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>')
    this.createForm();

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


    this.autoComplete();
  }

  getOrganismes() {
    this.uow.organismes.getByType(this.typeOrganisme).subscribe(r => {
      this.organismes = r as any;
    });
  }


  stateAxe() {
    if (this.router.url.includes('mesure-executif')) {
      this.type = 1;

    } else if (this.router.url.includes('mesure-programme')) {
      this.type = 2;

    } else {
      this.type = 3;
    }

    this.uow.axes.stateAxes(this.type, 0).subscribe(r => {

      r = r.filter(e => e.name !== null);
      // console.log(r);
      const barChartLabels = r.map(e => e.name);
      const dataToShowInTable = []
      const barChartData = [
        // { data: [], label: 'في طور الإنجاز'/*, stack: 'a'*/ },
        { data: [], label: 'منجز'/*, stack: 'a'*/ },
        { data: [], label: 'عمل متواصل'/*, stack: 'a'*/ },
        { data: [], label: 'غير منجز'/*, stack: 'a'*/ },
      ];

      r.forEach(e => {
        // barChartData[0].data.push((e.p * 100 / e.t).toFixed(0));
        barChartData[0].data.push((e.r * 100 / e.t).toFixed(0));
        barChartData[1].data.push((e.c * 100 / e.t).toFixed(0));
        barChartData[2].data.push((e.n * 100 / e.t).toFixed(0));
      });


      // tslint:disable-next-line:max-line-length
      this.examenPageSubject.next({ barChartLabels, barChartData, title: 'وضعية التنفيذ حسب المحاور الرئسية' });
    });
  }


  stateOneOFMecanisme() {
    if (this.router.url.includes('mesure-executif')) {
      this.type = 1;

    } else if (this.router.url.includes('mesure-programme')) {
      this.type = 2;

    } else {
      this.type = 3;
    }

    this.uow.realisations.stateMecanisme(this.type).subscribe(r => {
      const chartLabels = [];
      // chartLabels.push('في طور الإنجاز');
      chartLabels.push('منجز');
      chartLabels.push('عمل متواصل');
      chartLabels.push('غير منجز');

      console.log(r)

      const chartData = [];
      const dataToShowInTable = [];

      // chartData.push(r.epu.p * r.epu.t / 100);
      // chartData.push(r.epu.r * r.epu.t / 100);
      // chartData.push(r.epu.t - (r.epu.p * r.epu.t / 100) - (r.epu.r * r.epu.t / 100));

      // chartData.push(r.epu.p * 100 / r.epu.t);
      chartData.push(r.epu.r * 100 / r.epu.t);
      chartData.push(r.epu.c * 100 / r.epu.t);
      chartData.push(r.epu.n * 100 / r.epu.t);

      dataToShowInTable.push(r.epu.p, r.epu.r, r.epu.c, r.epu.n);
      this.countRec.next(r.epu.p + r.epu.r + r.epu.c + r.epu.n);

      // chartData.push(100 - r.epu.t);


      const chartColors = [ '#2b960b', '#db0707', '#ffffff'];

      this.dataEpuPie.next({
        chartLabels, chartData, chartColors, dataToShowInTable, count: r.count
        , title: 'وضعية التنفيذ'
      });

    });
  }

  checkWitchMesure(r: string) {
    if (r.includes('mesure-region')) {
      this.title = 'المخطط التنفيدي الترابي';
      this.isMesureRegion = true;
      this.isMesure = false;
      this.isProgramme = false;
      this.typeOrganisme = 2;
      this.getOrganismes();
    } else if (r.includes('mesure-programme')) {
      this.title = 'برامج العمل';
      this.isMesureRegion = false;
      this.isMesure = false;
      this.isProgramme = true;
      this.typeOrganisme = 3;
      this.getOrganismes();
    } else {
      // mesure-executif
      this.title = 'المخطط التنفيدي';
      this.isMesureRegion = false;
      this.isMesure = true;
      this.isProgramme = false;
      this.typeOrganisme = 1;
      this.getOrganismes();
    }
  }

  navToUpdate(id = 0) {
    // console.log(`${this.routeMesure.replace('/list', '')}/update`, 0)
    this.router.navigate([`${this.routeMesure.replace('/list', '')}/update`, id]);
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
      idOrganisme: this.o.idOrganisme,
      typeOrganisme: this.o.typeOrganisme,
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
        this.users = [];
      });
    } else if (name === 'mesure') {
      this.uow.users.getByForeignKey(id).subscribe(r => {
        this.users = r as any[];
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
    this.update.next(true);
  }

  detail(o) {
    this.uow.mesures.getOneWithInclude(o.id).subscribe(r => {
      this.openDialog(r);
    });
  }

  openDialog(o: any) {
    const dialogRef = this.dialog.open(DetailsComponent, {
      width: '7100px',
      disableClose: true,
      data: { model: o, title: this.title },
      direction: 'rtl',
    });

    return dialogRef.afterClosed();
  }

  searchAndGet(o: Model) {
    this.o = o;
    // this.o.idOrganisme = this.session.isPointFocal || this.session.isProprietaire ? this.session.user.idOrganisme : this.o.idOrganisme;
    this.uow.organismes.searchAndGet(this.o).subscribe(
      (r: any) => {
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.resultsLengthTadabir = r.countMesures;
        this.isLoadingResults = false;
      }, e => this.isLoadingResults = false,
    );

  }

  getPage(data: Model) {
    this.uow.organismes.searchAndGet(data).subscribe(
      (r: any) => {
        console.log(r.list);
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.resultsLengthTadabir = r.countMesures;
        this.isLoadingResults = false;
      }
    );
  }




  searchAndGetOld(o: Model) {
    this.o = o;
    // this.o.idOrganisme = this.session.isPointFocal || this.session.isProprietaire ? this.session.user.idOrganisme : this.o.idOrganisme;
    this.uow.mesures.searchAndGet(this.o).subscribe(
      (r: any) => {
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.isLoadingResults = false;
      }, e => this.isLoadingResults = false,
    );

  }

  async delete(o: Mesure) {
    const r = await this.mydialog.openDialog('تدبير').toPromise();
    if (r === 'ok') {
      this.uow.mesures.delete(o.id).subscribe(() => this.update.next(true));
    }
  }

  axeChange(idAxe: number) {
    this.uow.sousAxes.getByIdAxe(idAxe).subscribe(r => {
      this.sousAxes = r as any[];
    });
  }

  async expandeRow(row: Organisme) {

    if (this.expandedElement.id !== row.id) {
      row = await this.uow.organismes.getInfoResponsable(row.id).toPromise() as Organisme;
    }
    return this.expandedElement = this.expandedElement.id === row.id ? new Organisme() : row;
  }
  get isAllEmpty(): boolean {
    if (this.myForm.get('idAxe').value.toString() === '0' &&
      this.myForm.get('idCycle').value.toString() === '0' &&
      this.myForm.get('idSousAxe').value.toString() === '0' &&
      this.myForm.get('idMesure').value.toString() === '0' &&
      this.myForm.get('idOrganisme').value.toString() === '0' &&
      this.myForm.get('idResponsable').value.toString() === '0') {
      return true;
    }
    return false;
  }

}

class Model {
  idCycle = 0;
  idOrganisme = 0;
  typeOrganisme = 1;
  startIndex = 0;
  pageSize = 10;
  sortBy = 'id';
  sortDir = 'desc';
}


