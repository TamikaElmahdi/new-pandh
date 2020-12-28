import { Component, OnInit, Input } from '@angular/core';
import { Subject, Observable, of } from 'rxjs';
import { MyTranslateService } from 'src/app/my.translate.service';
import { MatDialog } from '@angular/material';
import { DetailComponent } from '../detail/detail.component';

@Component({
  selector: 'app-progress-cercle',
  templateUrl: './progress-cercle.component.html',
  styleUrls: ['./progress-cercle.component.scss']
})
export class ProgressCercleComponent implements OnInit {
  @Input() width = 300;
  @Input() fontSize = .93;
  @Input() widthText = '';
  @Input() marginh5Title = '';

  @Input() marginLegend = '';
  @Input() marginLeftTitle = '';


  @Input() diameter = 120;
  @Input() transform = 50;
  @Input() public showLegend = false;
  @Input() public showTable = false;
  @Input() public isInForLoop = false;
  @Input() public data = new Subject<{ name: string | Observable<string>, t: number, p: number, r: number, nbt: number, nbp: number, nbr: number }>();
  @Input() o = { name: null, t: 0, p: 0, r:0, nbt: 0, nbp:0, nbr: 0 };
  @Input() public elementFromForLoop: { name: string | Observable<string>, p: number, t: number, r: number };

  retate = 0;
  count = 0;
  constructor(public mytranslate: MyTranslateService, public dialog: MatDialog) { }

  ngOnInit() {
    // this.mytranslate.lang.subscribe(lang => {
    //   this.retate = lang === 'fr' ? 0 : 180;
    // });
    // this.showLegend = this.showLegend;

    this.data.subscribe(async r => {

      if (r.name instanceof Observable) {
        r.name.subscribe(name => {
          this.o.name = name;
          this.o.t = r.t;
          this.o.p = r.p;
          this.o.r = r.r;
          this.count = (r as any).count;

          console.log((r as any).count)

          this.o.nbt = r.nbt;
          this.o.nbp = r.nbp;
          this.o.nbr = r.nbr;


          console.log(this.o)
        });

      } else {
        this.o = r;
      }

    });
  }

  tooltipMsg(prc: number, realise: number, taux: number) {
    if (this.mytranslate.langSync === 'fr') {
      return 'En cours : ' + prc + '% - Réalisé : ' + realise + '% - Taux : ' + taux.toFixed(0) + '%';
    }

    return `التقدم المحرز : ${prc} % - منجز : ${realise} % - نسبة ${taux.toFixed(0)} %    `;
    // return ` % ${taux.toFixed(0)} : نسبة - % ${prc} التقدم المحرز`;
  }

  openDialog() {
    const conf = {
      width: '7100px',
      disableClose: false,
      data: { model: this.o, type: 'cercle' , title: this.o.name}
    };

    this.dialog.open(DetailComponent, conf).afterClosed().subscribe(r => {
      console.log(r);
    });
  }

}
