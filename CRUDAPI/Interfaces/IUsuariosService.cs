using CRUDAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDAPI.Models{

    public interface IEventoService
    {
        void ProcessarFila();
        void GerarDadosTeste();
    }
}