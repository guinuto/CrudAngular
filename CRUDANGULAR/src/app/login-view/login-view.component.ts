import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup ,Validators} from '@angular/forms';
import { Login } from '../Login';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login-view',
  templateUrl: './login-view.component.html',
  styleUrls: ['./login-view.component.css']
})
export class LoginViewComponent implements OnInit {

  constructor(private router: Router) { 
    
  }

  ngOnInit(): void {
  }


  formulario = new FormGroup({
    nome : new FormControl(null,Validators.required ) ,
    password : new FormControl(null ,Validators.required) ,
  
  });

  enviarLogin () : void {
    const login : Login = this.formulario.value;
    var credencial = login.nome+':'+login.password;
    localStorage.setItem("usuario" , credencial);
    this.router.navigate(['/usuarios']);
  }



}
