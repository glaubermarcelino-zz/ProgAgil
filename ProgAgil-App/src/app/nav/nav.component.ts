import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private router: Router,
              private authService: AuthService, 
              private toastr: ToastrService) { }

  ngOnInit() {
  }
  loggedIn() {
        return this.authService.loggedIn();
  }
  logout() {
    localStorage.removeItem('token');
    this.toastr.show('Log Out');
    this.router.navigate(['/user/login']);
  }
  Entrar() {
    this.router.navigate(['/user/login']);
  }
}
