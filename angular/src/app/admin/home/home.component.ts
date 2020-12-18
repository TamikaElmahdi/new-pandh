import { SessionService } from 'src/app/shared';
import { UowService } from 'src/app/services/uow.service';
import { Component, OnInit, ViewChild, EventEmitter, ChangeDetectorRef } from '@angular/core';

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
  constructor(private uow: UowService, public session: SessionService) { }

  ngOnInit() {
    // this.uow.realisations.pourcentageParAxe(1).subscribe((r: any[]) => { this.countG1 = r.toString()});
    // this.uow.realisations.pourcentageParAxe(2).subscribe((r: any[]) => { this.countG2 = r.toString()});
    // this.uow.realisations.pourcentageParAxe(3).subscribe((r: any[]) => { this.countG3 = r.toString()});
    // this.uow.realisations.pourcentageParAxe(4).subscribe((r: any[]) => { this.countG4 = r.toString()});

  }

  pandh() {
    window.location.href = 'https://www.didh.gov.ma/ar/publications/khtt-alml-alwtnyt-fy-mjal-aldymqratyt-whqwq-alansan-2018-2021/';
  }

}
