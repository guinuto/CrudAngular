import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import {HttpClientModule} from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsuariosService } from './usuarios.service';
import { ReactiveFormsModule } from '@angular/forms';
import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatButtonModule} from '@angular/material/button';
import {MatListModule} from '@angular/material/list';
import {MatTableModule} from '@angular/material/table';
import {MatFormFieldModule} from '@angular/material/form-field';
import { LoginViewComponent } from './login-view/login-view.component';
import {MatSelectModule} from '@angular/material/select';
import { InterceptorModule } from './Interceptor/interceptor.module';

@NgModule({
  declarations: [
    AppComponent,
    UsuariosComponent,
    LoginViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatListModule,
    MatTableModule,
    MatFormFieldModule,
    MatSelectModule,
    InterceptorModule

  ],
  providers: [HttpClientModule,UsuariosService],
  bootstrap: [AppComponent]
})
export class AppModule { }
