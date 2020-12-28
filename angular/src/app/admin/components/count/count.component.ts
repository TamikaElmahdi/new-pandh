import { Component, Input, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { MyTranslateService } from 'src/app/my.translate.service';

@Component({
  selector: 'app-count',
  templateUrl: './count.component.html',
  styleUrls: ['./count.component.scss']
})
export class CountComponent implements OnInit {
  year = new Date().getFullYear();
  @Input() count = new Subject();
  @Input() height = '62vh';
  @Input() ifEpu = false;


  constructor(public mytranslate: MyTranslateService) { }

  ngOnInit() {
  }

}
