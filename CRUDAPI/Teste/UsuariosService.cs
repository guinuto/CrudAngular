using CRUDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPI.Models;

    
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepo;
        public EventoService(IEventoRepository eventoRepo)
        {
            _eventoRepo = eventoRepo;
        }

        public void ProcessarFila()
        {
            Console.WriteLine("Obtendo a lista:");
            var lista = _eventoRepo.Listar();
            Console.WriteLine("Objetos obtidos:" + lista.Count());
            foreach (var item in lista)
            {
                Console.WriteLine("Novo cadastro de pessoa  de nome :" + item.nome) ;
            }
            Console.WriteLine("Pressione uma tecla para finalizar!");
            Console.ReadKey();
        }

        

        public void GerarDadosTeste()
        {
            var evento = new EventoModel()
            {
                nome = "Jose",
                cpf = "05050505050",
                email = "joseluiz@gmail.com",
                 type = "F",
                
               
            };

            var evento2 = new EventoModel(){
                nome = "Ana",
                cpf = "01010101010",
                email = "analuiza@gmail.com",
                
                type = "C",
               

            };
            _eventoRepo.Incluir(evento);
            _eventoRepo.Incluir(evento2);
        }
    }
