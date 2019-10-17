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

  titulo          = 'Editar Evento';
  registerForm    : FormGroup;
  imagemURL       = 'assets/img/upload.png';
  evento          : Evento = new Evento();
  file            : File;
  fileNameToUpdate: string;
  dataAtual       = '';

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
        id                : [],
        tema              : ['',  [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
        local             : ['', [Validators.required]],
        dataEvento        : ['', [Validators.required]],
        qtdPessoas        : ['', [Validators.required, Validators.max(120000)]],
        imagemURL         : [''],
        telefone          : ['', [Validators.required]],
        email             : ['', [Validators.required, Validators.email]],
        lotes             : this.fb.array([]),
        redesSociais      : this.fb.array([])
      });
    }

    criaLote(lote: any): FormGroup {
      return this.fb.group({
        id        : [lote.idEvento],
        nome      : [lote.nome, Validators.required],
        quantidade: [lote.quantidade, Validators.required],
        preco     : [lote.preco, Validators.required],
        dataInicio: [lote.dataInicio],
        dataFim   : [lote.dataFim]
      });
    }
    criaredeSocial(redeSocial: any): FormGroup {
      return  this.fb.group({
        id  : [redeSocial.id],
        nome: [redeSocial.nome, Validators.required],
        url : [redeSocial.url, Validators.required]
      });
    }

    adicionarLote() {
      this.lotes.push(this.criaLote({id: 0}));
    }

    adicionarRedeSocial() {
      this.redesSociais.push(this.criaredeSocial({ id: 0}));
    }
    removerRedeSocial(id: number) {
      this.redesSociais.removeAt(id);
    }

    removerLote(id: number) {
      this.lotes.removeAt(id);
    }

    onFileChange(evento: any, file: FileList) {
      const reader  = new FileReader();
      reader.onload = (event: any) => this.imagemURL = event.target.result;
      this.file     = evento.target.files;
      reader.readAsDataURL(file[0]);
    }

    carregarEvento() {
      const idEvento = +this.router.snapshot.paramMap.get('id');
      this.service.getEventoById(idEvento)
      .subscribe((evento: Evento) => {
        this.evento = evento;
        this.fileNameToUpdate = evento.imagemURL.toString();
        this.dataAtual = new Date().getMilliseconds().toString();
        this.imagemURL = `http://localhost:5000/Resources/Images/${ evento.imagemURL }?_ts=${this.dataAtual}`;
        this.evento.imagemURL = '';
        this.registerForm.patchValue(evento);
        this.evento.lotes
            .forEach(lote => {
                      this.lotes.push(this.criaLote(lote));
        });

        this.evento.redesSociais.forEach(redeSocial => {
          this.redesSociais.push(this.criaredeSocial(redeSocial));
        });
      }, error => {
        this.toastService.error(`Ocorreu um erro ao buscar o evento Nº ${idEvento}`);
      });
    }
    salvarEvento() {
      this.evento = Object.assign({ id: this.evento.id },  this.registerForm.value);
        this.evento.imagemURL = this.fileNameToUpdate;
        this.uploadImagem();
        
        this.service.putEvento(this.evento).subscribe(
          () => {
            this.toastService.success('Atualizado com sucesso', 'Sucesso');
          },
          error => {
            this.toastService.error(`Erro ao atualizar ${error}`, 'Erro');
          }
          );
        }
        uploadImagem() {
          if (this.registerForm.get('imagemURL').value !== '') {

            console.log(this.file);
            console.log(this.fileNameToUpdate);

            this.service
                .postUpload(this.file, this.fileNameToUpdate)
                .subscribe(
                  () => {
                    this.dataAtual = new Date().getMilliseconds().toString();
                    this.imagemURL = `http://localhost:5000/Resources/Images/${ this.evento.imagemURL }?_ts=${this.dataAtual}`;
                  });
            }
          }
        }
