import { ListComponent } from './list/list.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StateRoutingModule } from './state-routing.module';
import { StateComponent } from './state.component';
import { HttpClientModule } from '@angular/common/http';
import { MatModule } from 'src/app/mat.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TitleModule } from '../components/title/title.module';
import { PieChartModule } from '../components/pie-chart/pie-chart.module';
import { CountModule } from '../components/count/count.module';


@NgModule({
  declarations: [
    StateComponent,
    ListComponent,
  ],
  imports: [
    CommonModule,
    StateRoutingModule,
    HttpClientModule,
    MatModule,
    FormsModule,
    ReactiveFormsModule,
    TitleModule,
    PieChartModule,
    CountModule
  ],
  entryComponents: [
  ]
})
export class StateModule { }
