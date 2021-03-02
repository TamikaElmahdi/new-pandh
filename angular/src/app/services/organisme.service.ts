import { Injectable } from '@angular/core';
import { SuperService } from './super.service';

@Injectable({
  providedIn: 'root'
})
export class OrganismeService  extends SuperService<any> {

  constructor() {
    super('organisme');
  }

  // getByForeignKey(id) {
  //   return this.http.get(`${this.urlApi}/${this.controller}/getByForeignKey/${id}`);
  // }

  getByType(id) {
    return this.http.get(`${this.urlApi}/${this.controller}/getByType/${id}`);
  }

  getDataFiltre(searchText) {
    return this.http.get(`${this.urlApi}/${this.controller}/getDataFiltre/${searchText}`);
  }

  getListByType(startIndex, pageSize, sortBy, sortDir, type) {
    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${type}`);
  }

  getResponsableByForeignKey(id) {
    return this.http.get(`${this.urlApi}/${this.controller}/getResponsableByForeignKey/${id}`);
  }
  getResponsableByMesure(startIndex, pageSize, sortBy, sortDir,id) {
    return this.http.get(`${this.urlApi}/${this.controller}/getResponsableByMesure/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${id}`);
  }

  searchAndGet(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/searchAndGet`, o);
  }

  getInfoResponsable(id) {
    return this.http.get(`${this.urlApi}/${this.controller}/getInfoResponsable/${id}`);
  }


}
