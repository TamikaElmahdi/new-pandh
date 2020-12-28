import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { ChartOptions, ChartType } from 'chart.js';
import { Label, SingleDataSet, monkeyPatchChartJsTooltip, monkeyPatchChartJsLegend } from 'ng2-charts';
import { Subject, Observable } from 'rxjs';
import { MyTranslateService } from 'src/app/my.translate.service';
import { UowService } from 'src/app/services/uow.service';
import { DetailComponent } from '../detail/detail.component';
import * as pluginLabels from 'chartjs-plugin-labels';

@Component({
  selector: 'app-pie',
  templateUrl: './pie.component.html',
  styleUrls: ['./pie.component.scss']
})
export class PieComponent implements OnInit {
  // @Input() table: 'axe' | 'organe' | 'visite' = 'axe';
  // @Input() type: 'count' | 'taux' = 'taux';
  // @Input() mytitle: '';
  @Input() obs = new Subject<any>();
  @Input() public showLegend = true;
  @Input() withGraphe = '100%';
  @Input() height = '50vh';
  dataToShowInTable = [];
  title = '' || null;

  arr2 = new Subject();
  index = 0;
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
      enabled: true,
      callbacks: {
        label: (tooltipItem, data) => {
          const dataLabel = data.labels[tooltipItem.index];
          const value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];

          // console.log(dataLabel, value)

          return dataLabel;
        }
      }
    },
    hover: {
      mode: 'nearest',
      intersect: false,
      onHover: (e, item) => { }
    },
    legend: {
      position: 'bottom',
      // position: 'right',
      display: false,
      align: 'center',
      labels: {
        fontSize: 16,
      }
    },
    plugins: {
      labels: {
        fontColor: ['white', 'white', 'white', 'white', 'white', 'white', 'white', 'white', 'white', 'white', 'white', 'white',],
        precision: 0,
        fontSize: 14,
        fontStyle: 'bold',
        render: 'percentage',
        // render: (args, i) => {
        //   const label = args.label;
        //   const value = args.value;

        //   return `${value} % / (${this.dataToShowInTable[args.index]}) `;
        // }
      },
      pieceLabel: {
        // fontColor: '#000',
        render: (args) => {
          const label = args.label;
          const value = args.value;
          this.arr2.next(args);
          return label + ': ' + value;
        }
      }
    }


  };


  public pieChartLabels: Label[] = [/*['Download', 'Sales'], ['In', 'Store', 'Sales'], 'Mail Sales'*/];
  pieChartData: SingleDataSet = [/*300, 500, 100*/];
  @Input() public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartPlugins = [pluginLabels];
  public pieChartColors = [
    { backgroundColor: [], },
  ];
  list: { name: string, value: number }[] = [];
  retate = 0;
  arr: bigint[] = [];

  count: number; // count recommandations
  constructor(private uow: UowService, public mytranslate: MyTranslateService
    , public dialog: MatDialog) {
    monkeyPatchChartJsTooltip();
    monkeyPatchChartJsLegend();
  }

  ngOnInit() {
    // this.mytranslate.lang.subscribe(lang => {

    //   this.retate = lang === 'fr' ? 0 : 180;
    // });

    this.pieChartOptions.legend.display = this.showLegend;

    this.obs.subscribe(r => {
      this.title = r.title;
      this.pieChartLabels = r.chartLabels;
      this.pieChartData = r.chartData.map((e: number) => +e.toFixed(0));
      this.pieChartColors[0].backgroundColor = r.chartColors; // this.getColors(this.pieChartLabels.length);

      const rest = 100 - r.chartData.map((e: number) => +e.toFixed(0)).reduce((c, p) => c + p);

      if (rest > 10) {
        this.pieChartLabels.push('');
        this.pieChartData.push(rest);
        this.pieChartColors[0].backgroundColor.push('#fff')

        console.log('there is alot of space here', rest)
      }
      this.dataToShowInTable = r.dataToShowInTable.map((e: number) => e);
      this.count = r.count;
      // console.log(this.pieChartData, this.pieChartLabels);

      this.arr = r.chartData.map((e, i) => i);
      this.list = [];
      this.pieChartLabels.forEach((e, i) => {
        const value = this.pieChartData[i] as number;
        if (value !== 0) {
          this.list.push({
            name: e.toString(),
            value: this.pieChartData[i] as number,
          });
        }
      });
    });

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
      '#d97f2a', // orange
      '#2d71a1', // blue
      '#c2c3c6', // gray
      '#ba6446',
      '#7dc460', // green
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

  toInt(i: number) {
    return parseInt(((i / 3) - 1).toFixed(0), 10);
  }

  toStr(i: any) {
    return (parseInt((i).toFixed(0), 10) * this.count / 100).toFixed(0);
  }
}
