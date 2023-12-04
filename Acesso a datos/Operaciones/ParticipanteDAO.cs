using Acesso_a_datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acesso_a_datos.Operaciones
{
    public class ParticipanteDAO
    {
        //Creacion del contexto
        private Context.ConferenciasContext contexto = new Context.ConferenciasContext();
        
        //Retornamos una lista de todos los participantes(toda la info)
        public List<Participante> listaParticipantes()
        {
            var participantes = contexto.Participantes.ToList<Participante>();
            return participantes;
        }
        //Registrar un nuevo participante
        public bool nuevoParticipante(string nombre, string apellidos, string email, string twitter, string avatar)
        {
            try
            {
                Participante participante = new Participante();
                participante.Nombre = nombre;
                participante.Apellidos = apellidos;
                participante.Email = email;
                participante.Twitter = twitter;
                participante.Avatar = avatar;

                contexto.Participantes.Add(participante);
                contexto.SaveChanges();
                return true;
            }
            catch(Exception ex) 
            {
                return false;
            }
        }
        //Método para traer un participante por ID
        public Participante getParticipante(int id)
        {
            var participante = contexto.Participantes.Where(p => p.Id == id).FirstOrDefault();
            return participante;
        }
        //Editar participante
        public bool editarParticipante(int id, string nombre, string apellidos, string email, string twitter, string avatar)
        {
            try
            {
                var participante = getParticipante(id);
                if(participante == null)
                {
                    return false;
                }
                else
                {
                    participante.Nombre = nombre;
                    participante.Apellidos = apellidos;
                    participante.Email = email;
                    participante.Twitter = twitter; 
                    participante.Avatar = avatar;

                    contexto.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex) 
            {
                return false;
            }
        }
    }
}
