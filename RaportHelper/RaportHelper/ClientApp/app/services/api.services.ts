import { ContentType } from '@angular/http/src/enums';
import { Injectable } from '@angular/core';
import { Headers, Http, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/mergeMap';

import { Session } from '../models/session'
import { Task } from '../models/Task'

@Injectable()
export class ApiService {

  public apiUrl: string = 'http://localhost:33745/api';
  private headers = new Headers({'Content-Type': 'application/json'});

  constructor(private http: Http) {}

  getSession(token: string): Observable<Session> {
    return this.http.get(this.apiUrl+'session/'+token)
    .map(r => r.json() as Session)
    .catch(this.handleError);
  }

  addSession(name: string): void {
    this.http.post(this.apiUrl+'/session/add/'+name, {headers: this.headers})
      .map(() => null)
      .catch(this.handleError);
  }

  setSessionReady(token: string, isReady: number){
    this.http.get(this.apiUrl+'/session/'+token+'/'+isReady)
    .map(()=> null)
    .catch(this.handleError);
  }
 
  getTasks(id: number): Observable<Task>{
    return this.http.get(this.apiUrl+'/tasks/'+id)
      .map(r => r.json() as Task[])
      .catch(this.handleError);
  }

  addTask(task: Task): Observable<Task>{
      return this.http.post(this.apiUrl+'/tasks', JSON.stringify(task), {headers: this.headers})
        .map(() => null)
        .catch(this.handleError);
  }

  editTask(task: Task): Observable<Task>{
    return this.http.put(this.apiUrl+'/tasks', JSON.stringify(task), {headers: this.headers})
      .map(() => null)
      .catch(this.handleError);
  }

  deleteTask(task: Task): Observable<Task>{
    return this.http.post(this.apiUrl+'/tasks', JSON.stringify(task), {headers: this.headers})
      .map(() => null)
      .catch(this.handleError);
  }

 
  private handleError(error: any): Promise<any> {
    return Promise.reject(error.message || error);
  }

}