import { Component, OnInit, Input } from '@angular/core';
import { ChartOptions, ChartType } from 'chart.js';
import { Label, SingleDataSet, monkeyPatchChartJsTooltip, monkeyPatchChartJsLegend } from 'ng2-charts';
import { UowService } from 'src/app/services/uow.service';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-state-pie',
  templateUrl: './state.component.html',
  styleUrls: ['./state.component.scss']
})
export class StatePieComponent implements OnInit {
  // @Input() table: 'axe' | 'organe' | 'visite' = 'axe';
  // @Input() type: 'count' | 'taux' = 'taux';
  // @Input() mytitle: '';
  @Input() obs = new Subject<any>();
  title = '';
  // Pie
  public pieChartOptions: ChartOptions = {
    responsive: true,
    title: {
      text: '',
      display: false,
    },
    legend: {
      position: 'chartArea',
      display: false,
    }
  };



  pieChartLabels: Label[] = [/*['Download', 'Sales'], ['In', 'Store', 'Sales'], 'Mail Sales'*/];
  pieChartData: SingleDataSet = [/*300, 500, 100*/];
  public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartPlugins = [];
  public pieChartColors = [
    { backgroundColor: [], },
  ];

  constructor(private uow: UowService) {
    monkeyPatchChartJsTooltip();
    monkeyPatchChartJsLegend();
  }

  ngOnInit() {
    this.obs.subscribe((r: { list: {table: string, value: number}[], title: string }) => {
      console.log(r)
      this.title = r.title;
      this.pieChartLabels = r.list.map(e => e.table/*.split(' ')*/);
      this.pieChartData = r.list.map(e => e.value);
      this.pieChartColors[0].backgroundColor = this.getColors(this.pieChartLabels.length);
    });

  }

  getColors(length) {
    // tslint:disable-next-line:max-line-length
    const pallet = ['#0074D9', '#FF4136', '#2ECC40', '#FF851B', '#7FDBFF', '#B10DC9', '#FFDC00', '#001f3f', '#39CCCC', '#01FF70', '#85144b', '#F012BE', '#3D9970', '#111111', '#AAAAAA'];
    const colors = [];

    for (let i = 0; i < length; i++) {
      colors.push(pallet[i % pallet.length]);
    }

    return colors;
  }

}

export interface IData {
  table: 'axe' | 'organe' | 'visite';
  type: 'count' | 'taux';
  title: string;
}
