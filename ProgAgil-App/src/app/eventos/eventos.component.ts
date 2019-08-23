import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../_services/Evento.service';
import { Evento } from '../_models/Evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { defineLocale, BsLocaleService , ptBrLocale } from 'ngx-bootstrap';
defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {
  eventos: Evento[];
  evento: Evento;
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;
  eventosFiltrados: Evento[];
  registerForm: FormGroup;
  // tslint:disable-next-line:variable-name
  _filtroLista = '';

  get filtroLista(): string {
    return this._filtroLista;
  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEvento(this.filtroLista) : this.eventos;
  }
  constructor(
    private service: EventoService
    , private modalService: BsModalService
    , private fb: FormBuilder
    , private localeService: BsLocaleService
    ) {
      this.localeService.use('pt-br');
    }
    filtrarEvento(filtrarPor: string): Evento[] {
      filtrarPor = filtrarPor.toLocaleLowerCase();
      return this.eventos.filter(
        evento => evento.tema
        .toLocaleLowerCase()
        .indexOf(filtrarPor) !== -1);
      }
      alternarImagem() {
        this.mostrarImagem = !this.mostrarImagem;
      }
      ngOnInit() {
        this.validation();
        this.getEventos();
      }
      openModal(template: any) {
        template.show();
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
        salvarAlteracao(template: any) {
          if (this.registerForm.valid) {
              this.evento = Object.assign({}, this.registerForm.value);
              this.service.postEvento(this.evento)
                          .subscribe((novoEvento: Evento) => {
                              template.hide();
                              this.registerForm.reset();
                              console.log(novoEvento);
                              this.getEventos();
                          }, error => {
                              console.log('Ocorreu um erro ao salvar o evento');
                          });
          }
        }
        validation() {
          this.registerForm = this.fb.group({
            tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
            local: ['', [Validators.required]],
            dataEvento: ['', [Validators.required]],
            qtdPessoas: ['', [Validators.required, Validators.max(120000)]],
            imagemURL: ['', [Validators.required]],
            telefone: ['', [Validators.required]],
            email: ['', [Validators.required, Validators.email]]
          });
        }
      }