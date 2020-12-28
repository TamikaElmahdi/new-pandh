import { Component, OnInit, Input } from '@angular/core';
import { MyTranslateService } from 'src/app/my.translate.service';
import { MatDialog } from '@angular/material';
import { DetailComponent } from '../detail/detail.component';

@Component({
  selector: 'app-progress-bar',
  templateUrl: './progress-bar.component.html',
  styleUrls: ['./progress-bar.component.scss']
})
export class ProgressBarComponent implements OnInit {
  @Input() widthOne = 0;
  @Input() widthTwo = 0;
  @Input() widthThree = 0;
  @Input() title = '';

  rotateY = 0;
  constructor(public mytranslate: MyTranslateService, public dialog: MatDialog) { }

  ngOnInit() {
    this.mytranslate.lang.subscribe(r => {
      this.rotateY = r === 'fr' ? 0 : 180;
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
      data: { model: { name: this.title, t: this.widthTwo, p: this.widthTwo, r: this.widthThree }, type: 'cercle', title: this.title }
    };

    this.dialog.open(DetailComponent, conf).afterClosed().subscribe(r => {
      console.log(r);
    });
  }

}
