import { SessionService } from './../../../shared/session.service';
import { Notification, Organisme, Realisation, Mesure, Activite } from './../../../Models/models';
import { Component, OnInit, Input, EventEmitter } from '@angular/core';
import { Validators, FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UowService } from 'src/app/services/uow.service';
import { map, switchMap } from 'rxjs/operators';
import { Observable, BehaviorSubject } from 'rxjs';
import { MatAutocompleteSelectedEvent } from '@angular/material';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit {
  // eventToChild = new EventEmitter();
  // organismes = this.uow.organismes.get();
  public myForm: FormGroup;
  // axes = this.uow.axes.get();
  // mecanismes = this.uow.mecanismes;
  // etats = this.uow.etats;
  activites = [];
  //years = [];
  years = [2018, 2019, 2020, 2021, 2022, 2023, 2024, 2025, 2026];

  // activites = ['الأنشطة01', 'الأنشطة02', 'الأنشطة03', 'الأنشطة04'];
  cycles = this.uow.cycles.get();
  // planifications = ['1المخطط', '1المخطط', '1المخطط', '1المخطط', '1المخطط', '1المخطط', ];
  // sousAxes = [];
  // syntheses = this.uow.syntheses.get();
  o = new Realisation();
  id = 0;
  // title = 'Nouveau utilisateur';
  // listOrganisme: Organisme[] = [];
  cycleFC = new FormControl(0);
  mesure = new Mesure();
  myAuto = new FormControl('');
  filteredOptions: Observable<any>;
  situations = ['في طور الإنجاز', 'عمل متواصل', 'منجز', 'غير منجز'];
  sendMesureToIndicateurComponent = new BehaviorSubject(0);
  mesureId = 0;
  disabled = false;
  constructor(private route: ActivatedRoute, private router: Router,
    private uow: UowService, private fb: FormBuilder, private session: SessionService) { }

  ngOnInit() {

    this.createForm();
    this.id = +this.route.snapshot.paramMap.get('id');
    if (this.id !== 0) {
      this.uow.realisations.getOneWithInclude(this.id).subscribe(async r => {
        this.o = r as Realisation;
        this.o.activite = Object.assign(new Activite(), this.o.activite);
        //this.years = this.o.activite.dureeToArray();

        this.cycleFC.setValue(this.o.mesure.idCycle);
        this.myAuto.setValue(this.o.mesure.nom);

        this.sendMesureToIndicateurComponent.next(this.o.idMesure);
        this.activites = await this.uow.activites.getByForeignKey(this.o.idMesure).toPromise() as any;

        if(this.o.situation === 'منجز'){
          this.disabled = true;
        } else if(this.o.situation === 'غير منجز'){
          this.disabled = true;
        } else {
          this.disabled = false;

        }

        this.createForm();
        //this.myForm.get('annee').setValue(this.o.annee.toString());
        // this.eventToChild.emit(this.listOrganisme);
        // this.title = 'Modifier Utilisateur';

      });
    }

    this.autoComplete();
  }

  autoComplete() {
    // to remove just for the sack of simplicite
    // this.cycleFC.valueChanges.subscribe(id => {
    //   console.log('zdzdzdzd')
    //   return this.uow.mesures.getByForeignKey(this.cycleFC.value)
    //     .pipe(map(e => {
    //       console.log(e);
    //       return e;
    //     }));
    // });
    this.filteredOptions = this.myAuto.valueChanges.pipe(
      // startWith(''),
      switchMap((value: string) => {
        // return value.length > 1 && this.cycleFC.value !== 0 ? this.uow.mesures.customAutocomplete(this.cycleFC.value, value) : [];
        return value.length > 1 && this.cycleFC.value !== 0 ? this.uow.mesures.getByForeignKey(this.cycleFC.value) : [];
      }),
      // map(r => r)
    );
  }

  showTaux(valType: string) {
  //situations = ['في طور الإنجاز', 'عمل متواصل', 'منجز', 'غير منجز']

      if(valType === 'منجز'){
        this.myForm.controls.tauxRealisation.setValue(100);
        //this.myForm.controls['tauxRealisation'].disable();
        this.disabled = true;
      } else if(valType === 'غير منجز'){
        this.myForm.controls.tauxRealisation.setValue(0);
        //this.myForm.controls.tauxRealisation.disable();
        this.disabled = true;

      } else {
        //this.myForm.controls.tauxRealisation.enable();
        this.disabled = false;

      }

  }

  selected(event: MatAutocompleteSelectedEvent): void {
    this.mesure = event.option.value as Mesure;
    this.mesureId = this.mesure.id;
    console.log(this.mesure);
    this.myAuto.setValue(this.mesure.nom);
    // this.mySubsForm.get('placeId').setValue(this.place.id);
    this.uow.activites.getByForeignKey(this.mesure.id).subscribe(r => {
      this.activites = r as any;
    });

    this.sendMesureToIndicateurComponent.next(this.mesure.id);

  }

  createForm() {
    this.myForm = this.fb.group({
      id: this.o.id,
      nom: [this.o.nom, Validators.required],
      situation: [this.o.situation, Validators.required],
      annee: [this.o.annee, Validators.required],
      taux: [this.o.taux],
      tauxRealisation: [this.o.tauxRealisation, [Validators.min(0), , Validators.max(100)]],
      effet: [this.o.effet],
      idActivite: [this.o.idActivite, Validators.required],
      idMesure: [this.o.idMesure, Validators.required],

    });
  }


  submit(o: Realisation) {
    // return;
    // alert(this.o.id);
    // alert(this.o.nom);
    // alert(this.o.situation);
    // alert(this.o.annee);
    // alert(this.o.taux);
    // alert(this.o.tauxRealisation);
    // alert(this.o.effet);
    // alert(this.o.idActivite);
    // alert(this.mesureId);

console.log(o);
    if (this.id === 0) {
      this.uow.realisations.post(o).subscribe((r: Realisation) => {
        this.router.navigate(['/admin/suivi']);
      });
    } else {
      this.uow.realisations.put(o.id, o).subscribe((r) => {
        this.router.navigate(['/admin/suivi']);
      });
    }
  }

  selectChange(id, name) {
    if (name === 'activite') {

      this.uow.activites.getOne(id).subscribe(r => {
        r = Object.assign(new Activite(), r);
        // this.myForm.get('annee').setValue(r.duree);
        //this.years = r.dureeToArray();
        // console.log(this.myForm.get('annee').value)
      });
    } else if (name === 'cycle'){
      // this.uow.mesures.getOne(id).subscribe(r => {
      //   r = Object.assign(new Activite(), r);
      //   this.myForm.get('annee').setValue(r.duree);
      // });
    }

  }

  reset() {
    this.o = new Realisation();
    this.createForm();
  }
}

