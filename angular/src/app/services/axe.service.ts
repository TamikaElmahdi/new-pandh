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
    return this.http.get<{ name: string, p: number, t: number, r: number, c: number, n: number }[]>(`${this.urlApi}/${this.controller}/stateAxes/${type}/${isHome}`);
  }

  stateSousAxeByDepartement(idSousAxe: number) {
    return this.http.get<{ name: string, p: number, t: number, r: number, c: number, n: number }[]>(`${this.urlApi}/${this.controller}/stateSousAxeByDepartement/${idSousAxe}`);
  }

  stateMesuresByType(type: number) {
    return this.http.get<{ name: string, p: number,   t: number, r: number, c: number, n: number }[]>(`${this.urlApi}/${this.controller}/stateMesuresByType/${type}`);
  }

  stateOrganismeActivite(type: number) {
    return this.http.get<{ name: string, n: number, c: number, r: number, t: number, }[]>(`${this.urlApi}/${this.controller}/stateOrganismeActivite/${type}`);
  }

  // stateOrganismeActivite(type: number) {
  //   return this.http.get<{ name: string, val: number, t: number }[]>(`${this.urlApi}/${this.controller}/stateOrganismeActivite/${type}`);
  // }

  stateOrganismeMesure(type: number) {
    return this.http.get<{ name: string, n: number, c: number, r: number, t: number, }[]>(`${this.urlApi}/${this.controller}/stateOrganismeMesure/${type}`);
  }

  // stateOrganismeMesure(type: number) {
  //   return this.http.get<{ name: string, val: number, t: number }[]>(`${this.urlApi}/${this.controller}/stateOrganismeMesure/${type}`);
  // }

  stateAxeActivite(type: number) {
    return this.http.get<{ name: string, val: number, t: number }[]>(`${this.urlApi}/${this.controller}/stateAxeActivite/${type}`);
  }
  stateAxeMesure(type: number) {
    return this.http.get<{ name: string, val: number, t: number }[]>(`${this.urlApi}/${this.controller}/stateAxeMesure/${type}`);
  }

  stateSousAxeActivite(type: number) {
    return this.http.get<{ name: string, n: number, c: number, r: number, t: number, }[]>(`${this.urlApi}/${this.controller}/stateSousAxeActivite/${type}`);
  }

  // stateSousAxeActivite(type: number) {
  //   return this.http.get<{ name: string, val: number, t: number }[]>(`${this.urlApi}/${this.controller}/stateSousAxeActivite/${type}`);
  // }
  stateSousAxeMesure(type: number) {
    return this.http.get<{ name: string, n: number, c: number, r: number, t: number, }[]>(`${this.urlApi}/${this.controller}/stateSousAxeMesure/${type}`);
  }


}
