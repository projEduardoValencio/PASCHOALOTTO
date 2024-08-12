import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  //TODO: Ajustar url
  private apiUrl = 'https://randomuser.me/api/'; // Altere para a URL da sua API

  constructor(private http: HttpClient) {}

  getUsers(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}?results=10`); // Ajuste os parâmetros conforme necessário
  }
}
