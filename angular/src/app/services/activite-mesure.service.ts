import { Injectable } from '@angular/core';
import { SuperService } from './super.service';
import { ActiviteMesure } from '../Models/models';

@Injectable({
  providedIn: 'root'
})
export class ActiviteMesureService extends SuperService<ActiviteMesure> {

  constructor() {
    super('ActiviteMesures');
  }

  putRange(modelsToDelete, modelsToAdd) {
    return this.http.post(`${this.urlApi}/${this.controller}/putRange`, { modelsToDelete, modelsToAdd });
  }


  putActiviteMesure(model) {
    return this.http.post(`${this.urlApi}/${this.controller}/putActiviteMesure`, model);
  }

  getAll(startIndex, pageSize, sortBy, sortDir, id) {
    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${id}`);
  }

}
