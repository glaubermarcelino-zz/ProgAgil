import { Component, OnInit } from '@angular/core';
import { EventoService } from '../_services/Evento.service';
import { Evento } from '../_models/Evento';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {
  eventos: Evento[];
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

  eventosFiltrados: Evento[];

  constructor(private service: EventoService) {

  }
filtrarEvento(filtrarPor: string): Evento[] {
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
    this.service.getAllEventos()
    .subscribe(
    (_eventos: Evento[]) => {
        this.eventos = _eventos;
        this.eventosFiltrados = _eventos;
      }
    , error => {
        console.error(error);
    });
  }
}
