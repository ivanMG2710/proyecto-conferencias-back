using Acesso_a_datos.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acesso_a_datos.Operaciones
{
    public class ConferenciaDAO
    {
        //Creacion de la variable de contexto 
        private Context.ConferenciasContext contexto = new Context.ConferenciasContext();

        //Método para traer toda lista de las conferencias
        public List <Conferencium> listaConferencias() 
        {
            var conferencias = contexto.Conferencia.ToList<Conferencium>();
            return conferencias;
        }
        //Retorna una conferencia por un ID
        public Conferencium getConferencia(int id)
        {
            var conferencia = contexto.Conferencia.Where(c => c.Id == id).FirstOrDefault();
            return conferencia;
        }
        //Metodo para regresar todos los participantes de una conferencia
        public List<conferenciaAsistente> listaConferenciaAsistentes(int idConferencia)
        {
            var query = from c in contexto.Conferencia
                        join r in contexto.Registros on c.Id
                equals r.IdConferencia
                        join p in contexto.Participantes on
                r.IdParticipante equals p.Id
                where c.Id == idConferencia
                        select new conferenciaAsistente
                        {
                            nombreConferencia = c.NombreConfe,
                            fecha = c.Fecha,
                            horario = c.Horario,
                            nombreParticipante = p.Nombre,
                            apellidoParticipante = p.Apellidos,
                            avatar = p.Avatar
                        };
            return query.ToList();
        }
    }
}
