import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Lead } from './lead';

const baseUrl = "https://localhost:5001/";

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(
    private _client: HttpClient
  ) { }

  public get(): Observable<Lead[]> {
    return this._client.get<{ leads: Lead[] }>(`${baseUrl}api/data`)
      .pipe(
        map(x => x.leads)
      );
  }

  public create(lead: Lead ): Observable<{ id: number }> {
    return this._client.post<{ id: number }>(`${baseUrl}api/data`, { data: lead });
  }  
}
