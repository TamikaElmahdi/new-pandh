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
  countG1 = 15 ;
  countG2 = 25 ;
  countG3 = 26;
  countG4 = 24;
  departementSubjectA = new Subject();
  departementSubjectB = new Subject();
  departementSubjectC = new Subject();

  constructor(private uow: UowService, public session: SessionService) { }

  ngOnInit() {
    // this.uow.realisations.pourcentageParAxe(1).subscribe((r: any[]) => { this.countG1 = r.toString()});
    // this.uow.realisations.pourcentageParAxe(2).subscribe((r: any[]) => { this.countG2 = r.toString()});
    // this.uow.realisations.pourcentageParAxe(3).subscribe((r: any[]) => { this.countG3 = r.toString()});
    // this.uow.realisations.pourcentageParAxe(4).subscribe((r: any[]) => { this.countG4 = r.toString()});
    this.stateAxe(1);
    this.stateAxe(2);
    this.stateAxe(3);
  }

  stateAxe(type) {
      this.uow.axes.stateAxes(type).subscribe(r => {
        r = r.filter(e => e.name !== null);
        // console.log(r);
        const barChartLabels = r.map(e => e.name);
        const dataToShowInTable = []
        const barChartData = [
          { data: [], label: 'في طور الإنجاز'/*, stack: 'a'*/ },
          { data: [], label: 'منجز'/*, stack: 'a'*/ },
          { data: [], label: 'غير منجز'/*, stack: 'a'*/ },
        ];

        r.forEach(e => {
          barChartData[0].data.push((e.p * 100 / e.t).toFixed(0));
          barChartData[1].data.push((e.r * 100 / e.t).toFixed(0));
          barChartData[2].data.push((e.n * 100 / e.t).toFixed(0));
        });

        // tslint:disable-next-line:max-line-length
      if(type === 1)
          this.departementSubjectA.next({ barChartLabels, barChartData, title: '' });
      else if(type === 2)
        this.departementSubjectB.next({ barChartLabels, barChartData, title: '' });
      else if(type === 3)
        this.departementSubjectC.next({ barChartLabels, barChartData, title: '' });
      });


  }

  pandh() {
    window.location.href = 'https://www.didh.gov.ma/ar/publications/khtt-alml-alwtnyt-fy-mjal-aldymqratyt-whqwq-alansan-2018-2021/';
  }

}
