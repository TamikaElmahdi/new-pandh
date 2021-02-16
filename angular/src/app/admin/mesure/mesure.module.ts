import { ListComponent } from './list/list.component';
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
import { DetailsComponent } from './details/details.component';
import { PieChartModule } from '../components/pie-chart/pie-chart.module';
import { CountModule } from '../components/count/count.module';


@NgModule({
  declarations: [
    MesureComponent,
    ListComponent,
    UpdateComponent,
    PartenaireComponent,
    ResponsableComponent,
    ResponsablesComponent,
    IndicateurComponent,
    ActiviteComponent,
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
