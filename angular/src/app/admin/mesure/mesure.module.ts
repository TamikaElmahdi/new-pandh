import { ListOldComponent } from './listOld/listOld.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MesureRoutingModule } from './mesure-routing.module';
import { MesureComponent } from './mesure.component';
import { HttpClientModule } from '@angular/common/http';
import { MatModule } from 'src/app/mat.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TitleModule } from '../components/title/title.module';
import { UpdateComponent } from './update/update.component';
import { PartenaireComponent } from './partenaire/partenaire.component';
import { ResponsableComponent } from './responsable/responsable.component';
import { ResponsablesComponent } from './responsables/responsables.component';
import { IndicateurComponent } from './indicateur/indicateur.component';
import { ActiviteComponent } from './activite/activite.component';
import { ActivitesComponent } from './activites/activites.component';
import { DetailsComponent } from './details/details.component';
import { PieChartModule } from '../components/pie-chart/pie-chart.module';
import { CountModule } from '../components/count/count.module';
import { ListComponent } from './list/list.component';
import { ListMesureComponent } from './listMesure/listMesure.component';


@NgModule({
  declarations: [
    MesureComponent,
    ListComponent,
    ListMesureComponent,
    ListOldComponent,
    UpdateComponent,
    PartenaireComponent,
    ResponsableComponent,
    ResponsablesComponent,
    IndicateurComponent,
    ActiviteComponent,
    ActivitesComponent,
    DetailsComponent,
  ],
  imports: [
    CommonModule,
    MesureRoutingModule,
    HttpClientModule,
    MatModule,
    FormsModule,
    ReactiveFormsModule,
    TitleModule,
    PieChartModule,
    CountModule
  ],
  entryComponents: [
    DetailsComponent,
  ]
})
export class MesureModule { }
