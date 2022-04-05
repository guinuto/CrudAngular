using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace CRUDAPI.Models
{
    public class EventoModel
    {
        [Key]
        public int usuarioId { get; set; }
        public string? nome { get; set; }
        public string? cpf { get; set; }
        
        public string? email { get; set; }
        public string? type { get; set; }
    }
}