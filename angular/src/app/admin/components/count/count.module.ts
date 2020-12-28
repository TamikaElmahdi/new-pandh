import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CountComponent } from './count.component';
import { TranslateModule } from '@ngx-translate/core';



@NgModule({
  declarations: [CountComponent],
  imports: [
    CommonModule,
    TranslateModule,
  ],
  exports: [CountComponent]
})
export class CountModule { }
