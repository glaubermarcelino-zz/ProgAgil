import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpClient } from '@angular/common/http';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  titulo = 'Login';
  model: any = {};

  constructor(public router: Router,
              private toastr: ToastrService,
              private authService: AuthService) { }

  ngOnInit() {
    if (localStorage.getItem('token') !== null) {
      this.router.navigate(['/dashboard']);
    }
  }
login() {
  console.log(this.model);
  this.authService
      .login(this.model)
      .subscribe(() => {
        this.router.navigate(['/dashboard']);
      }, error => {
          this.toastr.error(`Falha no logon! Erro: ${error.error}`);
      });
}
}

