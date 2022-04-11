import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup ,Validators} from '@angular/forms';
import { Usuario } from 'src/app/Usuario';
import { UsuariosService } from 'src/app/usuarios.service';





@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  formulario: any;
    
  tituloFormulario!: string;
  usuarios! : Usuario[];
  visibilidadeTabela : boolean = true;
  visibilidadeFormulario : boolean = false;
  

  constructor(private usuariosService: UsuariosService) { }

  ngOnInit(): void {

    this.usuariosService.PegarTodos().subscribe(resultado=> {
      this.usuarios=resultado;
    })

    
  }

  ExibirFormularioCadastro():void{
    this.visibilidadeTabela = false;
    this.visibilidadeFormulario = true;
    this.tituloFormulario = "Novo Usuario";
    this.formulario = new FormGroup({
      nome : new FormControl(null,Validators.required ) ,
      cpf : new FormControl(null ,[Validators.maxLength(11) , Validators.minLength(11) ,Validators.required]) ,
      email : new FormControl(null,[Validators.email , Validators.required,Validators.minLength(5)]) ,
      type : new FormControl(null,[Validators.required,Validators.maxLength(1) ]) 
    });
  }

  
  ExibirFormularioAtualizacao(usuarioId: number) : void{
    console.log(usuarioId);
    this.visibilidadeTabela=false;
    this.visibilidadeFormulario=true;
    this.usuariosService.PegarPeloId(usuarioId).subscribe(resultado =>{
      console.log(resultado);
      this.tituloFormulario= `Atualizar ${resultado.nome}`;
      this.formulario = new FormGroup({
        usuarioId: new FormControl(resultado.usuarioId ),
        nome: new FormControl(resultado.nome,Validators.required),
        cpf: new FormControl(resultado.cpf,[Validators.maxLength(11) , Validators.minLength(11) ,Validators.required]),
        email: new FormControl(resultado.email,[Validators.email , Validators.required,Validators.minLength(5)]),
        type: new FormControl(resultado.type,[Validators.required,Validators.maxLength(1) ])

      });
    });

  }

  Voltar():void{
    this.visibilidadeTabela=true;
    this.visibilidadeFormulario=false
  }


  EnviarFormulario():void{
    
    
    const usuario:Usuario = this.formulario.value;
    if(usuario.usuarioId>0){
      this.usuariosService.AtualizarUsuario(usuario).subscribe(resultado =>{
        this.visibilidadeFormulario=false;
        this.visibilidadeTabela=true;
        alert("Pessoa atualizada com sucesso");
        this.usuariosService.PegarTodos().subscribe((registros)=> {
         this.usuarios = registros;
        
        });
      });
    }else{
    
    
      this.usuariosService.SalvarUsuario(usuario).subscribe((resultado)=>{
      this.visibilidadeFormulario=false;
      this.visibilidadeTabela=true;
      alert("Pessoa inserida com sucesso");
      console.log(usuario);
      this.usuariosService.PegarTodos().subscribe((registros)=> {
        this.usuarios = registros;
      
    })
  });
  }
}



ExcluirUsuario(usuarioId: number):void{
  this.usuariosService.ExcluirUsuario(usuarioId).subscribe(resultado=>{
    alert("Pessoa excluida com sucesso");
    this.usuariosService.PegarTodos().subscribe(registros=> {
      this.usuarios=registros;
    });
  });
}



displayedColumns: string[] = ['nome', 'cpf', 'email', 'tipo','acoes' ];


get nome(){
  return this.formulario.get('nome')
}

get cpf(){
  return this.formulario.get('cpf')
}

get email(){
  return this.formulario.get('email')
}

get type(){
  return this.formulario.get('type')
}

  
}


