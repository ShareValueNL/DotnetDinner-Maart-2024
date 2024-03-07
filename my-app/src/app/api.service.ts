// api.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'http://localhost:8081'; // Replace with your API URL

  constructor(private http: HttpClient) { }

  getWinners(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/`);
  }
}