import { Injectable } from '@angular/core';
import { SuperService } from './super.service';

@Injectable({
  providedIn: 'root'
})
export class AxeService  extends SuperService<any> {

  constructor() {
    super('axes');
  }

  stateAxes(type: number, isHome: number) {
    return this.http.get<{ name: string, p: number, t: number, r: number, n: number }[]>(`${this.urlApi}/${this.controller}/stateAxes/${type}/${isHome}`);
  }

}
