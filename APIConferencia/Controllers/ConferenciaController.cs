using Acesso_a_datos.Models;
using Acesso_a_datos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIConferencia.Controllers
{
    [Route("api")]
    [ApiController]
    public class ConferenciaController : ControllerBase
    {
        private ConferenciaDAO conferenciaDAO = new ConferenciaDAO();

        //API para traer la lista de las conferencias
        [HttpGet("conferencias")]
        public List<Conferencium> getConferencia()
        {
            return conferenciaDAO.listaConferencias();
        }
        //API que devuelve una conferencia por su ID
        [HttpGet("conferenciaId")]
        public Conferencium getConferencia(int id)
        {
            return conferenciaDAO.getConferencia(id);
        }

        //API para ver los participantes en dichas conferencias
        [HttpGet("conferencia")]
        public List<conferenciaAsistente> asistenciaConfe(int id) 
        { 
            return conferenciaDAO.listaConferenciaAsistentes(id);
        }
    }
}
