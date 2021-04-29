import { Injectable } from '@angular/core';
import { SuperService } from './super.service';

@Injectable({
  providedIn: 'root'
})
export class SousAxeService  extends SuperService<any> {

  constructor() {
    super('sousAxes');
  }

  getByIdAxe(id) {
    return this.http.get(`${this.urlApi}/${this.controller}/getByIdAxe/${id}`);
  }


  stateSousAxesDetails(idAxe: number, idSousAxe: number) {
    return this.http.get<{ name: string, p: number, t: number, r: number, c: number, n: number }[]>(`${this.urlApi}/${this.controller}/stateSousAxesDetails/${idAxe}/${idSousAxe}`);
  }

}
