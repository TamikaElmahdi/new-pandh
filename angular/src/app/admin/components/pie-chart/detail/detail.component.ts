import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { MyTranslateService } from 'src/app/my.translate.service';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnInit {
  o: { name: '', t: 0, p: 0, r: 0, n: 0 } = { name: '', t: 0, p: 0, r: 0, n: 0 };
  list: { name: '', t: 0, p: 0, r: 0, n: 0 }[] | { name: string, value: number }[] = [];
  type = '';
  title = '';
  constructor(public dialogRef: MatDialogRef<any>, @Inject(MAT_DIALOG_DATA) public data: any
    , public mytranslate: MyTranslateService) { }

  ngOnInit() {
    // this.o = this.data.model;
    this.type = this.data.type;
    this.title = this.data.title;

    this.data.type === 'cercle' ? this.o = this.data.model : this.list = this.data.model;
    // this.title = this.data.title;
    console.log(this.o);

    // if (this.mytranslate.langSync === 'fr') {
    //   return 'État d\'avancement : ' + prc + '% - Réaliser : ' + realise + '% - Taux : ' + taux.toFixed(0) + '%';
    // }

    // return `التقدم المحرز : ${prc} % - منجز : ${realise} % - نسبة ${taux.toFixed(0)} %    `;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
