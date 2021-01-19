import { Injectable } from '@angular/core';
import { SuperService } from './super.service';
import { Realisation } from '../Models/models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RealisationService  extends SuperService<Realisation> {

  constructor() {
    super('Realisations');
  }

  // getAll(startIndex, pageSize, sortBy, sortDir, idSynthese) {
  //   return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${idSynthese}`);
  // }

  stateMecanisme(typeTable) {
    return this.http.get<{
      epu: { name: string | Observable<string>, p: number, t: number, r: number, n: number},
      ot: { name: string | Observable<string>, p: number, t: number, r: number , n: number},
      ps: { name: string | Observable<string>, p: number, t: number, r: number , n: number},
      count: number,
    }>(`${this.urlApi}/${this.controller}/stateMecanisme/${typeTable}`);
  }

  searchAndGet(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/searchAndGet`, o);
  }

  GetRapportLiterary(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/GetRapportLiterary`, o);
  }

  getRapportQualitative(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getRapportQualitative`, o);
  }

  pourcentageParAxe(type) {
    return this.http.get(`${this.urlApi}/${this.controller}/pourcentageParAxe/${type}`);
    }

    genericByRecommendation(table: 'axe' | 'sousAxe' | 'organe' | 'visite', type: string, typeTable: number) {
      return this.http.get<{ table: string, value: number }[]>(`${this.urlApi}/${this.controller}/genericByRecommendation/${table}/${type}/${typeTable}`);
    }

    genericByRecommendationSousAxe(type: string, typeTable: number , idAxe: number) {
      return this.http.get<{ table: string, value: number }[]>(`${this.urlApi}/${this.controller}/genericByRecommendationSousAxe/${type}/${typeTable}/${idAxe}`);
    }


}
