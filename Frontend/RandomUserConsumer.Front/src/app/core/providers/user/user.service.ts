import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'http://localhost:5208'; // Altere para a URL da sua API

  constructor(private http: HttpClient) {}

  searchUsers(page:number, pageSize:number, search:string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/user/list/${page}?pageSize=${pageSize}&search=${search}`); // Ajuste os parâmetros conforme necessário
  }
}
