import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TooltipModule, ModalModule, BsDropdownModule, BsDatepickerModule } from 'ngx-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';
import { NavComponent } from './nav/nav.component';

import { DatetimeFormatPipe } from './_helpers/datetimeFormat.pipe';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
   declarations: [
      AppComponent,
      EventosComponent,
      NavComponent,
      DatetimeFormatPipe,
      PalestrantesComponent,
      DashboardComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      BsDatepickerModule.forRoot(),
      TooltipModule.forRoot(),
      ModalModule.forRoot(),
      ToastrModule.forRoot(),
      BrowserAnimationsModule,
      ReactiveFormsModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
