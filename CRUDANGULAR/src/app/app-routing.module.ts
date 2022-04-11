import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { LoginViewComponent } from './login-view/login-view.component';

const routes: Routes = [{
  path:'usuarios' , component: UsuariosComponent
},
{
  path:'' , component: LoginViewComponent
},
{
  path:'loginView', component: LoginViewComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
