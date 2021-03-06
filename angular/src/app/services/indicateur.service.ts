import { Indicateur } from '../Models/models';
import { Injectable } from '@angular/core';
import { SuperService } from './super.service';

@Injectable({
  providedIn: 'root'
})
export class IndicateurService extends SuperService<Indicateur> {

  constructor() {
    super('Indicateurs');
  }

  // getByForeignKey(id) {
  //   return this.http.get(`${this.urlApi}/${this.controller}/getByForeignKey/${id}`);
  // }

  getDataFiltre(searchText) {
    return this.http.get(`${this.urlApi}/${this.controller}/getDataFiltre/${searchText}`);
  }

  putRange(modelsToDelete, modelsToAdd) {
    return this.http.post(`${this.urlApi}/${this.controller}/putRange`, { modelsToDelete, modelsToAdd });
  }

  getListIndicateur(startIndex, pageSize, sortBy, sortDir, id) {
    return this.http.get(`${this.urlApi}/${this.controller}/getListIndicateur/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${id}`);
  }
}
