import { Component, OnInit, Input } from '@angular/core';
import { ChartOptions, ChartType } from 'chart.js';
import { Label, SingleDataSet, monkeyPatchChartJsTooltip, monkeyPatchChartJsLegend } from 'ng2-charts';
import { UowService } from 'src/app/services/uow.service';
import { Subject, Observable } from 'rxjs';
import { MyTranslateService } from 'src/app/my.translate.service';
import { DetailComponent } from './detail/detail.component';
import { MatDialog } from '@angular/material';
import * as pluginLabels from 'chartjs-plugin-labels';
@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.scss']
})
export class PieChartComponent implements OnInit {
  // @Input() table: 'axe' | 'organe' | 'visite' = 'axe';
  // @Input() type: 'count' | 'taux' = 'taux';
  // @Input() mytitle: '';
  @Input() obs = new Subject<IData>();
  @Input() public showLegend = true;
  @Input() withGraphe = '100%';
  @Input() public positionLegendBottom = false;
  @Input() canvasHeight = 400;
  @Input() height = '45vh';

  title = '' || null;
  // Pie

  public pieChartOptions: ChartOptions = {
    responsive: true,
    maintainAspectRatio: false,
    cutoutPercentage: 50,
    title: {
      text: '',
      display: true,
    },
    tooltips: {
      enabled: true
    },
    legend: {
      //position: 'chartArea',
      position: 'bottom',
      display: false,
      align: 'center',
      fullWidth: true,
      labels: {
        fontSize: 16,
      }
    },
    plugins: {
      labels: {
        fontColor: ['white', 'white', 'white', 'white', 'white', 'white', 'white', 'white', 'white', 'white', 'white', 'white',],
        precision: 0,
        render: 'percentage',
        fontSize: 14,
        fontStyle: 'bold',
      },
      pieceLabel: {
        render: (args) => {
          const label = args.label;
          const value = args.value;
          return label + ': ' + value;
        }
      }
    }
  };


  public pieChartLabels: Label[] = [/*['Download', 'Sales'], ['In', 'Store', 'Sales'], 'Mail Sales'*/];
  pieChartData: SingleDataSet = [/*300, 500, 100*/];

  @Input() pieChartType: ChartType = 'pie';
  pieChartLegend = true;
  pieChartPlugins = [pluginLabels];
  pieChartColors = [
    { backgroundColor: [], },
  ];
  list: { name: string, value: number }[] = [];
  retate = 0;

  constructor(private uow: UowService, public mytranslate: MyTranslateService
    , public dialog: MatDialog) {
    monkeyPatchChartJsTooltip();
    monkeyPatchChartJsLegend();
  }

  ngOnInit() {
    // this.mytranslate.lang.subscribe(lang => {

    //   this.retate = lang === 'fr' ? 0 : 180;
    // });
    // this.pieChartOptions.legend.position = this.positionLegendBottom === false ? 'right' : 'bottom';
    // this.pieChartOptions.legend.display = this.showLegend;

    this.obs.subscribe(d => {
      // if (d.type === 'stateRecommendationByMecanismeTaux' as any) {
      //   this.title = d.title;
      //   this.uow.recommendations.stateRecommendationByMecanismeTaux().subscribe(r => {
      //     this.pieChartLabels = r.map(e => e.table/*.split(' ')*/);
      //     this.pieChartData = r.map(e => e.value);

      //     this.pieChartColors[0].backgroundColor = this.getColors(this.pieChartLabels.length);
      //   });
      // } else if (d.type === 'stateRecommendationByMecanismePercentage' as any) {
      //   this.title = d.title;
      //   this.uow.recommendations.stateRecommendationByMecanismePercentage().subscribe(r => {
      //     this.pieChartLabels = r.map(e => e.table/*.split(' ')*/);
      //     this.pieChartData = r.map(e => e.value);

      //     this.pieChartColors[0].backgroundColor = this.getColors(this.pieChartLabels.length);
      //   });
      // } else {

      // }

      if (d.title instanceof Observable) {
        d.title.subscribe(t => this.title = t)
      } else {
        this.title = d.title;
      }

      // this.uow.recommendations.genericByRecommendation(d.table, d.type).subscribe(r => {
      //   console.log(r)
      //   this.pieChartLabels = r.map(e => e.table/*.substring(0, 40) + ' ...'*/);
      //   this.pieChartData = r.map(e => +e.value.toFixed(0));
      //   this.pieChartColors[0].backgroundColor = this.getColors(this.pieChartLabels.length);

      //   this.pieChartLabels.forEach((e, i) => {
      //     const value = this.pieChartData[i] as number;
      //     if (value !== 0) {
      //       this.list.push({
      //         name: r[i].table.toString(),
      //         value: this.pieChartData[i] as number,
      //       });
      //     }
      //   });

      // });

    });

    // this.pieChartOptions.title.text = this.mytitle;
    //   this.uow.recommendations.genericByRecommendation(this.table, this.type).subscribe(r => {
    //     console.log(r);
    //     this.pieChartLabels = r.map(e => e.table/*.split(' ')*/);
    //     this.pieChartData = r.map(e => e.value);

    //     this.pieChartColors[0].backgroundColor = this.getColors(this.pieChartLabels.length);
    //   });

  }

  openDialog() {
    const conf = {
      width: '7100px',
      disableClose: false,
      data: { model: this.list, type: 'pie', title: this.title }
    };

    this.dialog.open(DetailComponent, conf).afterClosed().subscribe(r => {
      console.log(r);
    });
  }

  getColors(length) {
    // tslint:disable-next-line:max-line-length
    const pallet = [
      '#d97f2a',
      '#2d71a1',
      '#c2c3c6',
      '#ba6446',
      '#7dc460',
      '#fdb93a',
      '#59b8ce',
      '#5c5c5f',
      '#ef4f42',
      '#a5a6aa',
      // '#85144b', a31414
      // '#F012BE',
      // '#3D9970',
      // '#111111',
      // '#AAAAAA',
    ];
    // const pallet = ['#d17c36', '#496488', '#84bc5b'];
    const colors = [];

    for (let i = 0; i < length; i++) {
      colors.push(pallet[i % pallet.length]);
    }

    return colors;
  }

}

export interface IData {
  table: 'axe';
  type: 'taux' | 'etat' | 'realise';
  title: string | Observable<string>;
}
