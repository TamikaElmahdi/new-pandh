import { Indicateur, Mesure } from '../Models/models';
import { Injectable } from '@angular/core';
import { SuperService } from './super.service';

@Injectable({
  providedIn: 'root'
})
export class MesureService extends SuperService<Mesure> {

  constructor() {
    super('Mesures');
  }

  searchAndGet(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/searchAndGet`, o);
  }

  customAutocomplete(idCycle, name) {
    return this.http.get(`${this.urlApi}/${this.controller}/customAutocomplete/${idCycle}/${name}`);
  }


  getByOrganisme(id) {
    return this.http.get(`${this.urlApi}/${this.controller}/getByOrganisme/${id}`);
  }
  // getByTypeOrganisme(id) {
  //   return this.http.get(`${this.urlApi}/${this.controller}/getByTypeOrganisme/${id}`);
  // }

  pourcentageParSituation(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/PourcentageParSituation`, o);
  }

  getDataAxes(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getDataAxes`, o);
  }

  getDataSousAxes(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getDataSousAxes`, o);
  }



}
