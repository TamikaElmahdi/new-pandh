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
      epu: { name: string | Observable<string>, p: number, t: number, r: number , c: number , n: number},
      ot: { name: string | Observable<string>, p: number, t: number, r: number , c: number , n: number},
      ps: { name: string | Observable<string>, p: number, t: number, r: number , c: number , n: number},
      count: number,
    }>(`${this.urlApi}/${this.controller}/stateMecanisme/${typeTable}`);
  }

  stateMecanismeMesure(typeTable) {
    return this.http.get<{
      epu: { name: string | Observable<string>, t: number, r: number , c: number , n: number},
      count: number,
    }>(`${this.urlApi}/${this.controller}/stateMecanismeMesure/${typeTable}`);
  }

  stateMecanismeByType(typeTable, axe, type) {
    return this.http.get<{
      epu: { name: string | Observable<string>, p: number, t: number, r: number , c: number , n: number},
      count: number,
    }>(`${this.urlApi}/${this.controller}/stateMecanismeByType/${typeTable}/${axe}/${type}`);
  }

  stateMecanismeByTypeDetails(typeTable, axe, sousAxe, type) {
    return this.http.get<{
      epu: { name: string | Observable<string>, p: number, t: number, r: number , c: number , n: number},
      count: number,
    }>(`${this.urlApi}/${this.controller}/stateMecanismeByTypeDetails/${typeTable}/${axe}/${sousAxe}/${type}`);
  }


  stateSousAxesDetailsColors( axe, sousAxe) {
    return this.http.get<{
      epu: { name: string | Observable<string>, t: number, r: number , c: number , n: number},
      count: number,
    }>(`${this.urlApi}/${this.controller}/stateSousAxesDetailsColors/${axe}/${sousAxe}`);
  }



  stateMecanismeByDepartementDetails(typeTable, axe, sousAxe, departement) {
    return this.http.get<{
      epu: { name: string | Observable<string>, t: number, r: number , c: number , n: number},
      count: number,
    }>(`${this.urlApi}/${this.controller}/stateMecanismeByDepartementDetails/${typeTable}/${axe}/${sousAxe}/${departement}`);
  }



  getCountAndPourcentage(o) {
    return this.http.get<{
      epu: {  nonTermine: number, termine: number, encourRealisation: number , encontinue: number},
    }>(`${this.urlApi}/${this.controller}/getCountAndPourcentage/${o}`);
  }


  getNbNonTermine(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getNbNonTermine`, o);
  }

  getNbTermine(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getNbTermine`, o);
  }

  getNbContinue(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getNbContinue`, o);
  }

  getNbEncours(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getNbEncours`, o);
  }


  getNbNonTermineMesure(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getNbNonTermineMesure`, o);
  }

  getNbTermineMesure(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getNbTermineMesure`, o);
  }

  getNbEncoursMesure(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getNbEncoursMesure`, o);
  }

  //-----------------

  getPourcentageNonTermine(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getPourcentageNonTermine`, o);
  }

  getPourcentageTermine(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getPourcentageTermine`, o);
  }

  getPourcentageContinue(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getPourcentageContinue`, o);
  }

  getPourcentageEncours(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getPourcentageEncours`, o);
  }

  getPourcentageNonTermineMesure(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getPourcentageNonTermineMesure`, o);
  }

  getPourcentageTermineMesure(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getPourcentageTermineMesure`, o);
  }

  getPourcentageEncoursMesure(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getPourcentageEncoursMesure`, o);
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

    genericByRecommendationType(type: string, typeTable: number) {
      return this.http.get<{ table: string, value: number }[]>(`${this.urlApi}/${this.controller}/genericByRecommendationType/${type}/${typeTable}`);
    }


}
