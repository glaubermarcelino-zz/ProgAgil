import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../_services/Evento.service';
import { Evento } from '../_models/Evento';
import { BsModalService } from 'ngx-bootstrap';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { defineLocale, BsLocaleService, ptBrLocale } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';

defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {
  file: File;
  FileName: string;
  titulo = 'Eventos';
  eventos: Evento[];
  evento: Evento;
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;
  eventosFiltrados: Evento[];
  registerForm: FormGroup;
  modoSalvar: string;
  bodyDeletarEvento = '';
  dataAtual: string;
  dataEvento: string;
  // tslint:disable-next-line:variable-name
  _filtroLista = '';
  fileNameToUpdate: string;

  get filtroLista(): string {
    return this._filtroLista;
  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista
      ? this.filtrarEvento(this.filtroLista)
      : this.eventos;
  }
  constructor(
    private service: EventoService,
    private modalService: BsModalService,
    private fb: FormBuilder,
    private localeService: BsLocaleService,
    private toastService: ToastrService
  ) {
    this.localeService.use('pt-br');
  }
  filtrarEvento(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }
  alternarImagem() {
    this.mostrarImagem = !this.mostrarImagem;
  }
  ngOnInit() {
    this.validation();
    this.getEventos();
  }
  editarEvento(evento: Evento, template: any) {
    this.modoSalvar = 'put';
    this.openModal(template);
    this.evento = evento;
    this.fileNameToUpdate = evento.imagemURL.toString();
    this.evento.imagemURL = '';
    this.registerForm.patchValue(evento);
  }
  novoEvento(template: any) {
    this.modoSalvar = 'post';
    this.openModal(template);
  }

  excluirEvento(evento: Evento, template: any) {
    this.openModal(template);
    this.evento = evento;
    this.bodyDeletarEvento = `Tem certeza que deseja excluir o Evento: ${evento.tema}, Código: ${evento.id}?`;
  }
  confirmeDelete(template: any) {
    this.service.deleteEvento(this.evento.id).subscribe(
      () => {
        template.hide();
        this.getEventos();
        this.toastService.success('Deletado com sucesso', 'Sucesso');
      },
      error => {
        this.toastService.error(`Erro ao tentar deletar ${error}`, 'Erro');
      }
    );
  }
  openModal(template: any) {
    this.FileName = '';
    this.registerForm.reset();
    template.show();
  }
  getEventos() {
    this.service.getAllEventos().subscribe(
      // tslint:disable-next-line:variable-name
      (_eventos: Evento[]) => {
        this.eventos = _eventos;
        this.eventosFiltrados = _eventos;
      },
      error => {
        this.toastService.error(`Erro ao tentar carregar ${error}`, 'Erro');
      }
    );
  }
  onFileChange(event) {
    const reader = new FileReader();

    if (event.target.files && event.target.files.length) {
      this.file = event.target.files;
      this.FileName = this.file[0].name;
    }
  }
  salvarAlteracao(template: any) {
    if (this.registerForm.valid) {
      if (this.modoSalvar === 'post') {
        this.evento = Object.assign({}, this.registerForm.value);
        this.uploadImagem();

        this.service.postEvento(this.evento).subscribe(
          () => {
            template.hide();
            this.registerForm.reset();
            this.getEventos();
            this.toastService.success('Inserido com sucesso', 'Sucesso');
            this.FileName = '';
          },
          error => {
            this.toastService.error(`Erro ao inserir ${error}`, 'Erro');
          }
        );
      } else {
        this.evento = Object.assign(
          { id: this.evento.id },
          this.registerForm.value
        );

        this.uploadImagem();

        this.service.putEvento(this.evento).subscribe(
          () => {
            template.hide();
            this.registerForm.reset();
            this.getEventos();
            this.toastService.success('Atualizado com sucesso', 'Sucesso');
          },
          error => {
            this.toastService.error(`Erro ao atualizar ${error}`, 'Erro');
          }
        );
      }
    }
  }
  uploadImagem() {
    if (this.modoSalvar === 'post') {
      const nomeArquivo = this.evento.imagemURL.split('\\', 3);
      this.evento.imagemURL = nomeArquivo[2];
      this.service.postUpload(this.file, nomeArquivo[2])
        .subscribe(
          () => {
            this.dataAtual = new Date().getMilliseconds().toString();
            this.getEventos();
          }
        );
    } else {
      this.evento.imagemURL = this.FileName;
      this.service.postUpload(this.file, this.FileName)
        .subscribe(
          () => {
            this.dataAtual = new Date().getMilliseconds().toString();
            this.getEventos();
          }
        );
    }
  }
  validation() {
    this.registerForm = this.fb.group({
      tema: [
        '',
        [Validators.required, Validators.minLength(4), Validators.maxLength(50)]
      ],
      local: ['', [Validators.required]],
      dataEvento: ['', [Validators.required]],
      qtdPessoas: ['', [Validators.required, Validators.max(120000)]],
      imagemURL: ['', [Validators.required]],
      telefone: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]]
    });
  }
}
