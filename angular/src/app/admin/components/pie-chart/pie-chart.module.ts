import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatModule } from 'src/app/mat.module';
import { ChartsModule } from 'ng2-charts';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PieChartComponent } from './pie-chart.component';
import { StatePieComponent } from './state/state.component';
import { BarComponent } from './bar/bar.component';
import { ProgressBarComponent } from './progress-bar/progress-bar.component';
import { ProgressCercleComponent } from './progress-cercle/progress-cercle.component';
import { TranslateModule } from '@ngx-translate/core';
import { DetailComponent } from './detail/detail.component';
import { PieComponent } from './pie/pie.component';



@NgModule({
  declarations: [PieChartComponent,
     StatePieComponent,
     BarComponent,
     ProgressBarComponent,
     ProgressCercleComponent,
     DetailComponent,
     PieComponent,
    ],
  imports: [
    CommonModule,
    MatModule,
    ChartsModule,
    TranslateModule,
    // FormsModule,
    // ReactiveFormsModule,
  ],
  exports: [
    PieChartComponent,
    StatePieComponent,
    BarComponent,
    ProgressBarComponent,
    ProgressCercleComponent,
    PieComponent,
  ],
  entryComponents: [
    DetailComponent,
  ]
})
export class PieChartModule { }
