using Acesso_a_datos.Models;
using Acesso_a_datos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIConferencia.Controllers
{
    [Route("api")]
    [ApiController]
    public class ParticipanteController : ControllerBase
    {
        private ParticipanteDAO participanteDAO = new ParticipanteDAO();
        
        //API para traer toda las lista de participantes
        [HttpGet("participantes")]
        public List <Participante> listaParticipantes() 
        {
            return participanteDAO.listaParticipantes();
        }

        //API para crear un nuevo participante
        [HttpPost("participante")]
        public bool crearParticipante([FromBody]Participante participante)
        {
            return participanteDAO.nuevoParticipante(participante.Nombre, participante.Apellidos, participante.Email,
                                                    participante.Twitter, participante.Avatar);
        }
        
        //API para un participante por ID
        [HttpGet("participante")]
        public Participante getParticipante(int id) 
        {
            return participanteDAO.getParticipante(id);
        }
        
        //API para editar o modificar un participante
        [HttpPut("participante")]
        public bool editarParticipante(int id, [FromBody]Participante participante) 
        {
            return participanteDAO.editarParticipante(id, participante.Nombre, participante.Apellidos, participante.Email,
                                                        participante.Twitter, participante.Avatar);
        }
    }
}
