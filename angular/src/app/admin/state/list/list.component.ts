import { Mesure } from './../../../Models/models';
import { Component, OnInit, ViewChild, EventEmitter } from '@angular/core';
import { MatPaginator, MatSort, MatDialog, MatTabGroup, MatAutocompleteSelectedEvent, MatInput } from '@angular/material';
import { BehaviorSubject, merge, Observable, Subject } from 'rxjs';
import { UowService } from 'src/app/services/uow.service';
import { SnackbarService } from 'src/app/shared/snakebar.service';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router, NavigationStart } from '@angular/router';
import { SessionService } from 'src/app/shared';
import { switchMap, map } from 'rxjs/operators';
import { DeleteService } from '../../components/delete/delete.service';
import { IData } from '../../components/pie-chart/pie-chart.component';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  @ViewChild('matgroup', { static: false }) myTab: MatTabGroup;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  // @ViewChild('myAutocomplete', { static: true }) myAutocomplete: MatInput;
  update = new EventEmitter();
  isLoadingResults = true;
  resultsLength = 0;
  isRateLimitReached = false;
  dataSource = [];
  situations = ['في طور الإنجاز', 'عمل متواصل', 'منجز', 'غير منجز'];
  situationsMesures = ['في طور الإنجاز', 'منجز', 'غير منجز'];

  pieChartSubjectC = new BehaviorSubject<IData>({ table: 'axe', type: 'tauxRealisation', typeTable: 1, title: 'التوزيع الحسب المحاور', idAxe: 0 });
  pieChartSubjectD = new BehaviorSubject<IData>({ table: 'axe', type: 'tauxRealisation', typeTable: 1, title: 'التوزيع الحسب النوع', idAxe: 6 });

  dataEpu = new Subject<{ name: string | Observable<string>, p: number, t: number, r: number, n: number }>();

  examenPageSubject = new Subject();
  examenPageSubjectDetails = new Subject();
  countRec = new Subject();
  dataEpuPie = new Subject();

  dataEpuPieType1 = new Subject();
  dataEpuPieType2 = new Subject();
  dataEpuPieType3 = new Subject();

  dataEpuPieType4 = new Subject();
  dataEpuPieType5 = new Subject();
  dataEpuPieType6 = new Subject();


  dataEpuPieType7 = new Subject();
  dataEpuPieType8 = new Subject();
  dataEpuPieType9 = new Subject();

  dataEpuPieType10 = new Subject();
  dataEpuPieType11 = new Subject();
  dataEpuPieType12 = new Subject();

  dataEpuPieTypeDetails1 = new Subject();
  dataEpuPieTypeDetails2 = new Subject();
  dataEpuPieTypeDetails3 = new Subject();

  idAxeDetails = 0;
  idSousAxeDetails = 0;

  // periodes = [2019, 2020, 2021, 2022, 2023];
  // planifications = ['1المخطط', '1المخطط', '1المخطط', '1المخطط', '1المخطط', '1المخطط',];
  // responsables = ['المخاطب الرسمي1', 'المخاطب الرسمي1', 'المخاطب الرسمي1', 'المخاطب الرسمي1', 'المخاطب الرسمي1', 'المخاطب الرسمي1',];

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
  mesures = [];
  axes = this.uow.axes.get();
  sousAxes = [];
  cycles = this.uow.cycles.get();
  users = [];
  //organismeFiltres = this.uow.organismes.getByType(1);
  myForm: FormGroup;
  myFormDetails: FormGroup;
  //
  displayedColumns = this.columnDefs.map(e => e.columnDef);
  // progress = 0;
  // message: any;
  // formData = new FormData();
  o = new Model();
  oDetails = new ModelDetails();
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

  sumNonRealise = '0';
  sumRealise = '0';
  sumEncourRealisation = '0';
  sumEnContinue = '0';

  pourcentageNonRealise = '0';
  pourcentageRealise = '0';
  pourcentageEncourRealisation = '0';
  pourcentageEnContinue = '0';

  sumNonRealiseMesure = '0';
  sumRealiseMesure = '0';
  sumEncourRealisationMesure = '0';

  pourcentageNonRealiseMesure = '0';
  pourcentageRealiseMesure = '0';
  pourcentageEncourRealisationMesure = '0';

  countActivite = 0;
  countMesure = 0;


  regions = ['الرباط', 'تمارة'];
  oranismes = ['الجامعة', 'الأكاديمية', 'محو الأمية'];
  title = '';
  constructor(public uow: UowService, private mydialog: DeleteService
    , private snack: SnackbarService, private fb: FormBuilder
    , public session: SessionService, public dialog: MatDialog
    , private route: ActivatedRoute, public router: Router) { }

  ngOnInit() {

    this.stateAxe();
    this.stateOneOFMecanisme();

    this.getOrganismes();
    this.routeMesure = this.router.url;
    this.checkWitchMesure(this.routeMesure);
    this.o.typeOrganisme = this.typeOrganisme;
    this.searchAndGet(this.o);
    this.stateAxeDetails();

    this.getCountBySituation(this.o);

    this.stateOneOFMecanismeByType(1, 1, this.dataEpuPieType1);
    this.stateOneOFMecanismeByType(1, 2, this.dataEpuPieType2);
    this.stateOneOFMecanismeByType(1, 3, this.dataEpuPieType3);

    this.stateOneOFMecanismeByType(2, 1, this.dataEpuPieType4);
    this.stateOneOFMecanismeByType(2, 2, this.dataEpuPieType5);
    this.stateOneOFMecanismeByType(2, 3, this.dataEpuPieType6);

    this.stateOneOFMecanismeByType(3, 1, this.dataEpuPieType7);
    this.stateOneOFMecanismeByType(3, 2, this.dataEpuPieType8);
    this.stateOneOFMecanismeByType(3, 3, this.dataEpuPieType9);


    this.stateOneOFMecanismeByType(4, 1, this.dataEpuPieType10);
    this.stateOneOFMecanismeByType(4, 2, this.dataEpuPieType11);
    this.stateOneOFMecanismeByType(4, 3, this.dataEpuPieType12);

    this.stateOneOFMecanismeByTypeDetails(1, this.dataEpuPieTypeDetails1);
    this.stateOneOFMecanismeByTypeDetails(2, this.dataEpuPieTypeDetails2);
    this.stateOneOFMecanismeByTypeDetails(3, this.dataEpuPieTypeDetails3);




    // console.warn('>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>')
    this.createForm();
    this.createFormDetails();

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
        this.stateAxeDetails();

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

    setTimeout(() => {
      this.reset();
      // this.idCycle.setValue(1);
    }, 300);
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
    this.uow.axes.stateAxes(0 , 0).subscribe(r => {

      r = r.filter(e => e.name !== null);
      // console.log(r);
      const barChartLabels = r.map(e => e.name);
      const dataToShowInTable = []
      const barChartData = [
        { data: [], label: 'في طور الإنجاز'/*, stack: 'a'*/ },
        { data: [], label: 'منجز'/*, stack: 'a'*/ },
        { data: [], label: 'عمل متواصل'/*, stack: 'a'*/ },
        { data: [], label: 'غير منجز'/*, stack: 'a'*/ },
      ];

      r.forEach(e => {
        barChartData[0].data.push((e.p * 100 / e.t).toFixed(0));
        barChartData[1].data.push((e.r * 100 / e.t).toFixed(0));
        barChartData[2].data.push((e.c * 100 / e.t).toFixed(0));
        barChartData[3].data.push((e.n * 100 / e.t).toFixed(0));
      });


      // tslint:disable-next-line:max-line-length
      this.examenPageSubject.next({ barChartLabels, barChartData, title: 'وضعية التنفيذ حسب المحاور' });
    });
  }

  stateAxeDetails() {

    this.uow.sousAxes.stateSousAxesDetails(this.idAxeDetails, this.idSousAxeDetails).subscribe(r => {

      r = r.filter(e => e.name !== null);
      // console.log(r);
      const barChartLabels = r.map(e => e.name);
      const dataToShowInTable = []
      const barChartData = [
        { data: [], label: 'في طور الإنجاز'/*, stack: 'a'*/ },
        { data: [], label: 'منجز'/*, stack: 'a'*/ },
        { data: [], label: 'عمل متواصل'/*, stack: 'a'*/ },
        { data: [], label: 'غير منجز'/*, stack: 'a'*/ },
      ];

      r.forEach(e => {
        barChartData[0].data.push((e.p * 100 / e.t).toFixed(0));
        barChartData[1].data.push((e.r * 100 / e.t).toFixed(0));
        barChartData[2].data.push((e.c * 100 / e.t).toFixed(0));
        barChartData[3].data.push((e.n * 100 / e.t).toFixed(0));
      });


      // tslint:disable-next-line:max-line-length
      this.examenPageSubjectDetails.next({ barChartLabels, barChartData, title: 'وضعية التنفيذ' });
    });
  }


  getCountBySituation(o: Model) {
    this.getNbNonTermine(o);
    this.getNbTermine(o);
    this.getNbContinue(o);
    this.getNbEncours(o);

    this.getNbNonTermineMesure(o);
    this.getNbTermineMesure(o);
    this.getNbEncoursMesure(o);

    this.getPourcentageBySituation(o);
  }


  getPourcentageBySituation(o: Model) {
    this.getPourcentageNonTermine(o);
    this.getPourcentageTermine(o);
    this.getPourcentageContinue(o);
    this.getPourcentageEncours(o);

    this.getPourcentageNonTermineMesure(o);
    this.getPourcentageTermineMesure(o);
    this.getPourcentageEncoursMesure(o);
  }


  getNbNonTermine(o: Model) {
    this.uow.realisations.getNbNonTermine(o).subscribe(r => {
      this.sumNonRealise = r.toString();
    });

  }

  getNbTermine(o: Model){
    this.uow.realisations.getNbTermine(o).subscribe(r => {
      this.sumRealise = r.toString();
    });
  }

  getNbContinue(o: Model){
    this.uow.realisations.getNbContinue(o).subscribe(r => {
      this.sumEnContinue = r.toString();
    });
  }

  getNbEncours(o: Model){
    this.uow.realisations.getNbEncours(o).subscribe(r => {
      this.sumEncourRealisation = r.toString();
    });
  }

  getNbNonTermineMesure(o: Model) {
    this.uow.realisations.getNbNonTermineMesure(o).subscribe(r => {
      this.sumNonRealiseMesure = r.toString();
    });
  }

  getNbTermineMesure(o: Model) {
    this.uow.realisations.getNbTermineMesure(o).subscribe(r => {
      this.sumRealiseMesure = r.toString();
    });
  }

  getNbEncoursMesure(o: Model){
    this.uow.realisations.getNbEncoursMesure(o).subscribe(r => {
      this.sumEncourRealisationMesure = r.toString();
    });
  }



  //--------------

  getPourcentageNonTermine(o: Model) {
    this.uow.realisations.getPourcentageNonTermine(o).subscribe(r => {
      this.pourcentageNonRealise = r.toString();
    });

  }

  getPourcentageTermine(o: Model){
    this.uow.realisations.getPourcentageTermine(o).subscribe(r => {
      this.pourcentageRealise = r.toString();
    });
  }

  getPourcentageContinue(o: Model){
    this.uow.realisations.getPourcentageContinue(o).subscribe(r => {
      this.pourcentageEnContinue = r.toString();
    });
  }

  getPourcentageEncours(o: Model){
    this.uow.realisations.getPourcentageEncours(o).subscribe(r => {
      this.pourcentageEncourRealisation = r.toString();
    });
  }

  getPourcentageNonTermineMesure(o: Model) {
    this.uow.realisations.getPourcentageNonTermineMesure(o).subscribe(r => {
      this.pourcentageNonRealiseMesure = r.toString();
    });
  }

  getPourcentageTermineMesure(o: Model) {
    this.uow.realisations.getPourcentageTermineMesure(o).subscribe(r => {
      this.pourcentageRealiseMesure = r.toString();
    });
  }

  getPourcentageEncoursMesure(o: Model){
    this.uow.realisations.getPourcentageEncoursMesure(o).subscribe(r => {
      this.pourcentageEncourRealisationMesure = r.toString();
    });
  }


  getCountAndPourcentage(o: Model)
    {
      this.uow.realisations.getCountAndPourcentage(o).subscribe(r => {
        //this.sumNonRealise = r.epu.nonTermine;
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

    this.uow.realisations.stateMecanisme(1).subscribe(r => {
      const chartLabels = [];
      chartLabels.push('في طور الإنجاز');
      chartLabels.push('منجز');
      chartLabels.push('عمل متواصل');
      chartLabels.push('غير منجز');

      console.log(r)

      const chartData = [];
      const dataToShowInTable = [];

      // chartData.push(r.epu.p * r.epu.t / 100);
      // chartData.push(r.epu.r * r.epu.t / 100);
      // chartData.push(r.epu.t - (r.epu.p * r.epu.t / 100) - (r.epu.r * r.epu.t / 100));

      chartData.push(r.epu.p * 100 / r.epu.t);
      chartData.push(r.epu.r * 100 / r.epu.t);
      chartData.push(r.epu.c * 100 / r.epu.t);
      chartData.push(r.epu.n * 100 / r.epu.t);

      dataToShowInTable.push(r.epu.p, r.epu.r, r.epu.c, r.epu.n);
      this.countRec.next(r.epu.p + r.epu.r + r.epu.c + r.epu.n);

      // chartData.push(100 - r.epu.t);


      const chartColors = ['#f7801e', '#2b960b', '#2d71a1', '#db0707'];

      this.dataEpuPie.next({
        chartLabels, chartData, chartColors, dataToShowInTable, count: r.count
        , title: 'وضعية التنفيذ'
      });

    });
  }

  typeToText(idType: number)
  {
    if(idType == 1)
      return 'الجانب التشريعي والمؤسساتي';
    else if(idType == 2)
      return 'التواصل والتحسيس';
    else
    return 'تقوية القدرات';
  }


  stateOneOFMecanismeByType(axe: number, type: number, control: Subject<unknown>) {

    this.uow.realisations.stateMecanismeByType(1, axe , type ).subscribe(r => {
      const chartLabels = [];
      chartLabels.push('في طور الإنجاز');
      chartLabels.push('منجز');
      chartLabels.push('عمل متواصل');
      chartLabels.push('غير منجز');

      console.log(r)

      const chartData = [];
      const dataToShowInTable = [];

      // chartData.push(r.epu.p * r.epu.t / 100);
      // chartData.push(r.epu.r * r.epu.t / 100);
      // chartData.push(r.epu.t - (r.epu.p * r.epu.t / 100) - (r.epu.r * r.epu.t / 100));

      chartData.push(r.epu.p * 100 / r.epu.t);
      chartData.push(r.epu.r * 100 / r.epu.t);
      chartData.push(r.epu.c * 100 / r.epu.t);
      chartData.push(r.epu.n * 100 / r.epu.t);

      dataToShowInTable.push(r.epu.p, r.epu.r, r.epu.c, r.epu.n);
      this.countRec.next(r.epu.p + r.epu.r + r.epu.c + r.epu.n);

      // chartData.push(100 - r.epu.t);


      const chartColors = ['#f7801e', '#2b960b', '#2d71a1', '#db0707'];

      control.next({
        chartLabels, chartData, chartColors, dataToShowInTable, count: r.count
        , title: this.typeToText(type)

      });

    });
  }


  stateOneOFMecanismeByTypeDetails(type: number, control: Subject<unknown>) {

    this.uow.realisations.stateMecanismeByTypeDetails(1, this.idAxeDetails, this.idSousAxeDetails, type ).subscribe(r => {
      const chartLabels = [];
      chartLabels.push('في طور الإنجاز');
      chartLabels.push('منجز');
      chartLabels.push('عمل متواصل');
      chartLabels.push('غير منجز');

      console.log(r)

      const chartData = [];
      const dataToShowInTable = [];

      // chartData.push(r.epu.p * r.epu.t / 100);
      // chartData.push(r.epu.r * r.epu.t / 100);
      // chartData.push(r.epu.t - (r.epu.p * r.epu.t / 100) - (r.epu.r * r.epu.t / 100));

      chartData.push(r.epu.p * 100 / r.epu.t);
      chartData.push(r.epu.r * 100 / r.epu.t);
      chartData.push(r.epu.c * 100 / r.epu.t);
      chartData.push(r.epu.n * 100 / r.epu.t);

      dataToShowInTable.push(r.epu.p, r.epu.r, r.epu.c, r.epu.n);
      this.countRec.next(r.epu.p + r.epu.r + r.epu.c + r.epu.n);

      // chartData.push(100 - r.epu.t);


      const chartColors = ['#f7801e', '#2b960b', '#2d71a1', '#db0707'];

      control.next({
        chartLabels, chartData, chartColors, dataToShowInTable, count: r.count
        , title: this.typeToText(type)

      });

    });
  }






  selectedTabChange(o: MatTabGroup) {

    this.stateAxe();
    this.stateOneOFMecanisme();

    this.stateOneOFMecanismeByType(1, 1, this.dataEpuPieType1);
    this.stateOneOFMecanismeByType(1, 2, this.dataEpuPieType2);
    this.stateOneOFMecanismeByType(1, 3, this.dataEpuPieType3);

    this.stateOneOFMecanismeByType(2, 1, this.dataEpuPieType4);
    this.stateOneOFMecanismeByType(2, 2, this.dataEpuPieType5);
    this.stateOneOFMecanismeByType(2, 3, this.dataEpuPieType6);

    this.stateOneOFMecanismeByType(3, 1, this.dataEpuPieType7);
    this.stateOneOFMecanismeByType(3, 2, this.dataEpuPieType8);
    this.stateOneOFMecanismeByType(3, 3, this.dataEpuPieType9);


    this.stateOneOFMecanismeByType(4, 1, this.dataEpuPieType10);
    this.stateOneOFMecanismeByType(4, 2, this.dataEpuPieType11);
    this.stateOneOFMecanismeByType(4, 3, this.dataEpuPieType12);

    this.stateOneOFMecanismeByTypeDetails(1, this.dataEpuPieTypeDetails1);
    this.stateOneOFMecanismeByTypeDetails(2, this.dataEpuPieTypeDetails2);
    this.stateOneOFMecanismeByTypeDetails(3, this.dataEpuPieTypeDetails3);

    this.getOrganismes();
    this.routeMesure = this.router.url;
    this.checkWitchMesure(this.routeMesure);
    this.o.typeOrganisme = this.typeOrganisme;
    this.searchAndGet(this.o);
    this.stateAxeDetails();

    //this.getCountBySituation(this.o);
    this.createForm();
    this.createFormDetails();

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
        this.stateAxeDetails();

      }
    );
    this.autoComplete();

  }
  checkWitchMesure(r: string) {
    this.title = 'إحصائيات';

    if (r.includes('mesure-region')) {
     // this.title = 'المخطط التنفيدي الترابي';
      this.isMesureRegion = true;
      this.isMesure = false;
      this.isProgramme = false;
      this.typeOrganisme = 2;
      this.getOrganismes();
    } else if (r.includes('mesure-programme')) {
      //this.title = 'برامج العمل';
      this.isMesureRegion = false;
      this.isMesure = false;
      this.isProgramme = true;
      this.typeOrganisme = 3;
      this.getOrganismes();
    } else {
      // mesure-executif
     // this.title = 'المخطط التنفيدي';
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
      idMesure: this.o.idMesure,
      idResponsable: this.o.idResponsable,
      idOrganisme: this.o.idOrganisme,
      typeOrganisme: this.o.typeOrganisme,
      idAxe: this.o.idAxe,
      idSousAxe: this.o.idCycle,
      codeMesure: this.o.codeMesure,
      nomMesure: this.o.nomMesure,
      situation: this.o.situation,
      situationMesure: this.o.situationMesure,
      idAxeDetails: this.o.idAxeDetails,
      idSousAxeDetails: this.o.idSousAxeDetails,
      startIndex: this.o.startIndex,
      pageSize: this.o.pageSize,
      sortBy: this.o.sortBy,
      sortDir: this.o.sortDir,
    });
  }

  createFormDetails() {
    this.myFormDetails = this.fb.group({
      idAxeDetails: this.o.idAxeDetails,
      idSousAxeDetails: this.o.idSousAxeDetails,
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

  selectChangeDetails(id, type) {
    if(type === 'axe'){
    this.idAxeDetails = id;
      this.uow.sousAxes.getByIdAxe(id).subscribe(r => {
        this.sousAxes = r as any[];
      });
    }
    else{
    this.idSousAxeDetails = id;

    }

  }

  reset() {
    this.o = new Model();
    this.createForm();
    this.createFormDetails();
    this.searchAndGet(this.o);
    this.stateAxeDetails();

    //this.getCountBySituation(this.o);
  }

  search(o: Model) {
    this.searchAndGet(o);
    //this.getCountBySituation(this.o);

    //this.o = o;
    ///this.update.next(true);
  }


  searchDetails(oDetails: ModelDetails) {
    this.stateAxeDetails();
    this.stateOneOFMecanismeByTypeDetails(1, this.dataEpuPieTypeDetails1);
    this.stateOneOFMecanismeByTypeDetails(2, this.dataEpuPieTypeDetails2);
    this.stateOneOFMecanismeByTypeDetails(3, this.dataEpuPieTypeDetails3);

  }

  // pourcentageParSituation(o: string) {

  //   // this.o.idOrganisme = this.session.isPointFocal || this.session.isProprietaire ? this.session.user.idOrganisme : this.o.idOrganisme;
  //   this.uow.mesures.pourcentageParSituation(this.o).subscribe(
  //     (r: any) => {
  //       console.log(r.list);
  //       this.sum1 = r.value;
  //       this.sum2 = r.value1;
  //       this.isLoadingResults = false;
  //     }, e => this.isLoadingResults = false,
  //   );
  // }


  searchAndGet(o: Model) {
    console.log(o);
    this.o = o;
    // this.o.idOrganisme = this.session.isPointFocal || this.session.isProprietaire ? this.session.user.idOrganisme : this.o.idOrganisme;
    this.uow.mesures.searchAndGet(this.o).subscribe(
      (r: any) => {
        console.log(r.list);
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.isLoadingResults = false;
        this.countMesure = r.count;
        this.countActivite = r.countActivite;
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
  idMesure = 0;
  idResponsable = 0;
  idAxe = 0;
  idSousAxe = 0;
  idOrganisme = 0;
  typeOrganisme = 1;
  nomMesure = '';
  codeMesure = '';
  situation = '';
  situationMesure = '';
  idAxeDetails = 0;
  idSousAxeDetails = 0;

  // mecanisme = '';
  startIndex = 0;
  pageSize = 10;
  sortBy = 'id';
  sortDir = 'desc';
}

class ModelDetails {

  idAxeDetails = 0;
  idSousAxeDetails = 0;

}




