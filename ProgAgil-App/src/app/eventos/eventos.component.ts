import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {
  eventos: any = [];
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;
  _filtroLista: string;

  get filtroLista(): string {
    return this._filtroLista;
  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEvento(this.filtroLista) : this.eventos;
  }

  eventosFiltrados: any = [];

  constructor(private http: HttpClient) {

  }
filtrarEvento(filtrarPor: string): any {
  filtrarPor = filtrarPor.toLocaleLowerCase();
  return this.eventos.filter(
    evento => evento.tema
              .toLocaleLowerCase()
              .indexOf(filtrarPor) !== -1);
}
  alternarImagem()  {
    this.mostrarImagem = !this.mostrarImagem;
  }
  ngOnInit() {
    this.getEventos();
  }
  getEventos() {
    this.http.get('http://localhost:5000/api/values')
    .subscribe(response => {
      this.eventos = response;
    }, error => {
        console.error(error);
    });
  }
}
