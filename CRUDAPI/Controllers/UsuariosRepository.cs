using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CRUDAPI;

namespace CRUDAPI.Models;


    [Authorize]
    [ApiController]
    [Route("api/Usuarios")]
    public class EventoRepository : IEventoRepository
    {
        


        private readonly DatabaseContext _context;
        public EventoRepository(DatabaseContext ctx )
        {
            _context = ctx;
        }

        [HttpDelete ("{UsuarioId}")]
        public bool Excluir(int UsuarioId)
        {
            var obj = this.Obter(UsuarioId);
            if (obj == null)
                return false;

            _context.Remove(obj);
            _context.SaveChanges();
            return true;
        }

        [HttpPost ]
        public EventoModel Incluir(EventoModel usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        [HttpPut ]
        public EventoModel Alterar(EventoModel usuario)
        {
            var Dobj = this.Obter(usuario.usuarioId);
            if(Dobj == null){
                return null;
            }
            _context.Remove(Dobj);
            _context.Add(usuario);
            _context.SaveChanges();
            return null;
        }

        [HttpGet]
        public IEnumerable<EventoModel> Listar()
        {
            return _context.Eventos.ToList();
        }

        [HttpGet("{UsuarioId}")]
        public EventoModel Obter(int UsuarioId)
        {
            return _context.Eventos.Where(a => a.usuarioId == UsuarioId).FirstOrDefault();
        }
    }
