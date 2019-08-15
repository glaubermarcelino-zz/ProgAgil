import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../_services/Evento.service';
import { Evento } from '../_models/Evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';

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
  eventosFiltrados: Evento[];

  // tslint:disable-next-line:variable-name
  _filtroLista = '';
  modalRef: BsModalRef;

  get filtroLista(): string {
    return this._filtroLista;
  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEvento(this.filtroLista) : this.eventos;
  }

  constructor(
        private service: EventoService,
        private modalService: BsModalService
        ) {

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
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
  getEventos() {
    this.service.getAllEventos()
    .subscribe(
    // tslint:disable-next-line:variable-name
    (_eventos: Evento[]) => {
        this.eventos = _eventos;
        this.eventosFiltrados = _eventos;
      }
    , error => {
        console.error(error);
    });
  }
}
