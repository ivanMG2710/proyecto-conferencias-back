using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acesso_a_datos.Models
{
    public class conferenciaAsistente
    {
        public string nombreConferencia { get; set; } = null;
        public string fecha { get; set; } = null;
        public string horario { get; set; } = null;
        public string nombreParticipante { get; set; } = null;
        public string apellidoParticipante { get; set; } = null;
        public string avatar { get; set; } = null;

    }
}
