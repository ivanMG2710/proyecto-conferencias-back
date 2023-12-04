using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acesso_a_datos.Models;

namespace Acesso_a_datos.Operaciones
{
    public class RegistroDAO
    {
        //Creacion del contexto
        private Context.ConferenciasContext contexto = new Context.ConferenciasContext();

        //Metodo de creacion de un nuev registro a conferencia
        public bool nuevoRegistro(int idParticipante,int idConferencia) 
        {
            try 
            {
                Registro registro = new Registro();
                registro.IdParticipante = idParticipante;
                registro.IdConferencia = idConferencia;

                contexto.Registros.Add(registro);
                contexto.SaveChanges();
                return true;
            }
            catch(Exception ex) 
            {
                return false;
            }
        }
    }
}
