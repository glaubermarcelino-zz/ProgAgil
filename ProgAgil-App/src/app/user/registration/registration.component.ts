import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  registerForm: FormGroup;
  
  constructor(public fb: FormBuilder, private toastService: ToastrService) {}
  ngOnInit() {
    this.validation();
  }
  validation() {
    this.registerForm = this.fb.group({
      fullName: ['', Validators.required],
      email   : ['', [Validators.required, Validators.email]],
      userName: ['', Validators.required],
      passwords: this.fb.group({
        password: ['', [Validators.required, Validators.minLength(4)]],
        confirmPassword: ['', [Validators.required, Validators.minLength(4)]]
      }, {validator : this.compararSenhas})
    });
  }
  cadastrarusuario() {
    console.log('usuario cadastrado');
  }
  compararSenhas(fb: FormGroup) {
    const confirmSenhaCtrl = fb.get('confirmPassword');
    if (confirmSenhaCtrl.errors == null || 'mismatch' in confirmSenhaCtrl.errors) {
      if (fb.get('password').value !== confirmSenhaCtrl.value ) {
        fb.get('password').setErrors({mismatch: true});
      } else {confirmSenhaCtrl.setErrors(null); }
    }
  }
}
