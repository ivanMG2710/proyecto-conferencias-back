using System;
using System.Collections.Generic;

namespace Acesso_a_datos.Models;

public partial class Registro
{
    public int Id { get; set; }

    public int IdConferencia { get; set; }

    public int IdParticipante { get; set; }

    public virtual Conferencium? IdConferenciaNavigation { get; set; } = null!;

    public virtual Participante? IdParticipanteNavigation { get; set; } = null!;
}
