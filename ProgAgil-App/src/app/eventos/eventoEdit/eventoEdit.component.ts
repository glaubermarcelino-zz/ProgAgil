import { Component, OnInit } from '@angular/core';
import { EventoService } from 'src/app/_services/Evento.service';
import { BsModalService, BsLocaleService } from 'ngx-bootstrap';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/_models/Evento';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-eventoEdit',
  templateUrl: './eventoEdit.component.html',
  styleUrls: ['./eventoEdit.component.css']
})
export class EventoEditComponent implements OnInit {

  titulo = 'Editar Evento';
  registerForm: FormGroup;
  imagemURL = 'assets/img/upload.png';
  evento: Evento = new Evento();
  fileNameToUpdate: string;

  get lotes(): FormArray {
    return <FormArray> this.registerForm.get('lotes');
  }

  get redesSociais(): FormArray {
    return <FormArray> this.registerForm.get('redesSociais');
  }

  constructor(
    private service: EventoService,
    private router: ActivatedRoute,
    private fb: FormBuilder,
    private localeService: BsLocaleService,
    private toastService: ToastrService
  ) {
    this.localeService.use('pt-br');
  }

  ngOnInit() {
    this.validation();
    this.carregarEvento();
  }
  validation() {
    this.registerForm = this.fb.group({
      tema              : ['',  [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local             : ['', [Validators.required]],
      dataEvento        : ['', [Validators.required]],
      qtdPessoas        : ['', [Validators.required, Validators.max(120000)]],
      imagemURL         : [''],
      telefone          : ['', [Validators.required]],
      email             : ['', [Validators.required, Validators.email]],
      lotes             : this.fb.array([this.criaLote()]),
      redesSociais      : this.fb.array([this.criaredeSocial()])
    });
  }

  criaLote(): FormGroup {
    return this.fb.group({
      nome      : ['', Validators.required],
      quantidade: ['', Validators.required],
      preco     : ['', Validators.required],
      dataInicio: [''],
      dataFim   : ['']
    });
  }
  criaredeSocial(): FormGroup {
      return  this.fb.group({
        nome: ['', Validators.required],
        url : ['', Validators.required]
      });
  }

  adicionarLote() {
    this.lotes.push(this.criaLote());
  }

  adicionarRedeSocial() {
    this.redesSociais.push(this.criaredeSocial());
  }
  removerRedeSocial(id: number) {
    this.redesSociais.removeAt(id);
  }

  removerLote(id: number) {
    this.lotes.removeAt(id);
  }

  onFileChange(file: FileList) {
    const reader = new FileReader();
    reader.onload = (event: any) => this.imagemURL = event.target.result;
    reader.readAsDataURL(file[0]);
  }
  carregarEvento() {
    const idEvento = +this.router.snapshot.paramMap.get('id');
    this.service.getEventoById(idEvento)
        .subscribe((evento: Evento) => {
          this.evento = evento;
          this.fileNameToUpdate = evento.imagemURL.toString();
          this.evento.imagemURL = '';
          this.registerForm.patchValue(evento);
        }, error => {
            this.toastService.error(`Ocorreu um erro ao buscar o evento Nº ${idEvento}`);
        });
  }
}
