import { SessionService } from 'src/app/shared';
import { UowService } from 'src/app/services/uow.service';
import { Component, OnInit, ViewChild, EventEmitter, ChangeDetectorRef } from '@angular/core';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  countMesure = this.uow.mesures.count();
  countActivite = this.uow.activites.count();
  countG1 = 9 ;
  countG2 = 11 ;
  countG3 = 7;
  countG4 = 5;
  departementSubject1 = new Subject();
  departementSubject2 = new Subject();
  departementSubject3 = new Subject();
  departementSubject4 = new Subject();
  departementSubject5 = new Subject();
  departementSubject6 = new Subject();

  departementSubject7 = new Subject();

  constructor(private uow: UowService, public session: SessionService) { }

  ngOnInit() {
    // this.uow.realisations.pourcentageParAxe(1).subscribe((r: any[]) => { this.countG1 = r.toString()});
    // this.uow.realisations.pourcentageParAxe(2).subscribe((r: any[]) => { this.countG2 = r.toString()});
    // this.uow.realisations.pourcentageParAxe(3).subscribe((r: any[]) => { this.countG3 = r.toString()});
    // this.uow.realisations.pourcentageParAxe(4).subscribe((r: any[]) => { this.countG4 = r.toString()});
    this.stateAxe(1);
    this.stateAxe(2);
    this.stateAxe(3);
    this.stateAxe(4);
    this.stateAxe(5);
    this.stateAxe(6);
    this.stateAxe(7);
  }

  stateAxe(type) {
      this.uow.axes.stateAxes(type, 1).subscribe(r => {
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
          let total = e.p + e.r + e.c + e.n ;
          barChartData[0].data.push((e.p * 100 / total).toFixed(0));
          barChartData[1].data.push((e.r * 100 / total).toFixed(0));
          barChartData[2].data.push((e.c * 100 / total).toFixed(0));
          barChartData[3].data.push((e.n * 100 / total).toFixed(0));


        });

        // tslint:disable-next-line:max-line-length
      if(type === 1)
          this.departementSubject1.next({ barChartLabels, barChartData, title: '' });
      else if(type === 2)
        this.departementSubject2.next({ barChartLabels, barChartData, title: '' });
      else if(type === 3)
        this.departementSubject3.next({ barChartLabels, barChartData, title: '' });
        else if(type === 4)
        this.departementSubject4.next({ barChartLabels, barChartData, title: '' });
        else if(type === 5)
        this.departementSubject5.next({ barChartLabels, barChartData, title: '' });
        else if(type === 6)
        this.departementSubject6.next({ barChartLabels, barChartData, title: '' });
        else if(type === 7)
        this.departementSubject7.next({ barChartLabels, barChartData, title: '' });
      });


  }

  pandh() {
    window.location.href = 'https://www.didh.gov.ma/ar/publications/khtt-alml-alwtnyt-fy-mjal-aldymqratyt-whqwq-alansan-2018-2021/';
  }

}
