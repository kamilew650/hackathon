import { ContentType } from '@angular/http/src/enums';
import { Injectable } from '@angular/core';
import { Headers, Http, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/mergeMap';

import {Session} from '../models/session'

@Injectable()
export class ApiService {

  public apiUrl: string = 'http://localhost:33745/api';

  constructor(private http: Http) {}

  getSession(token: string): Observable<Session> {
    return this.http.get(this.apiUrl+'session/'+token)
    .map(r => r as Session)
    ._catch(this.handleError);
  }
 

 
  private handleError(error: any): Promise<any> {
    return Promise.reject(error.message || error);
  }

}