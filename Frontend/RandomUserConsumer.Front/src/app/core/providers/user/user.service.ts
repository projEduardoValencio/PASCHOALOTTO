import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {IResponseUserSearch} from "../../interfaces/responses/IResponseUserSearch";
import {IResponseUserGenerated} from "../../interfaces/responses/IResponseUserGenerated";
import {IResponseUserDetail} from "../../interfaces/responses/IResponseUserDetail";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'http://localhost:5208'; // Altere para a URL da sua API

  constructor(private http: HttpClient) {}

  searchUsers(page:number, pageSize:number, search:string): Observable<any> {
    return this.http.get<IResponseUserSearch>(`${this.apiUrl}/user/list/${page}?pageSize=${pageSize}&search=${search}`); // Ajuste os parâmetros conforme necessário
  }

  generateUser(): Observable<IResponseUserGenerated> {
    return this.http.get<IResponseUserGenerated>(`${this.apiUrl}/user/generate`); // Ajuste os parâmetros conforme necessário
  }

  getUser(id:number): Observable<IResponseUserDetail> {
    return this.http.get<any>(`${this.apiUrl}/user/find/${id}`); // Ajuste os parâmetros conforme necessário
  }
}
