import { Injectable } from '@angular/core';
import { SuperService } from './super.service';
import { Responsable } from '../Models/models';

@Injectable({
  providedIn: 'root'
})
export class ResponsableService extends SuperService<Responsable> {

  constructor() {
    super('Responsables');
  }

  putRange(modelsToDelete, modelsToAdd) {
    return this.http.post(`${this.urlApi}/${this.controller}/putRange`, { modelsToDelete, modelsToAdd });
  }



}
