using Acesso_a_datos.Models;
using Acesso_a_datos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIConferencia.Controllers
{
    [Route("api")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private RegistroDAO registroDAO = new RegistroDAO();
        
        //API para hacer un nuevo registro de participante a una conferencia
        [HttpPost("registros")]
        public bool registrar([FromBody]Registro registro)
        {
            return registroDAO.nuevoRegistro(registro.IdParticipante, registro.IdConferencia);
        }
    }
}
