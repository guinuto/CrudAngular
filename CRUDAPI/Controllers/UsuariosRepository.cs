using CRUDAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Models;

    [ApiController]
    [Route("api/EventoRepository")]
    public class EventoRepository : IEventoRepository
    {
        private readonly DatabaseContext _context;
        public EventoRepository(DatabaseContext ctx )
        {
            _context = ctx;
        }

        [HttpDelete ("{EventoId}")]
        public bool Excluir(int EventoId)
        {
            var obj = this.Obter(EventoId);
            if (obj == null)
                return false;

            _context.Remove(obj);
            _context.SaveChanges();
            return true;
        }

        [HttpPost]
        public EventoModel Incluir(EventoModel obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        [HttpPut]
        public EventoModel Alterar(EventoModel obj)
        {
            var Dobj = this.Obter(obj.usuarioId);
            if(Dobj == null){
                return null;
            }
            _context.Remove(Dobj);
            _context.Add(obj);
            _context.SaveChanges();
            return null;
        }

        public IEnumerable<EventoModel> Listar()
        {
            return _context.Eventos.ToList();
        }

        [HttpGet("{EventoId}")]
        public EventoModel Obter(int EventoId)
        {
            return _context.Eventos.Where(a => a.usuarioId == EventoId).FirstOrDefault();
        }
    }
