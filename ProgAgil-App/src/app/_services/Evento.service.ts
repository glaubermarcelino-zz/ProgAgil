import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Evento } from '../_models/Evento';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventoService {
  private baseUrl = 'http://localhost:5000/api/Evento';

  constructor(private http: HttpClient) { }

  getAllEventos(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseUrl);
  }
  getEventoByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseUrl);
  }
  getEventoById(Id: number): Observable<Evento> {
    return this.http.get<Evento>(`${this.baseUrl}/${Id}`);
  }
   postEvento(evento: Evento) {
    return this.http.post(this.baseUrl, evento);
  }
}
