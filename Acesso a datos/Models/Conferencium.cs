using System;
using System.Collections.Generic;

namespace Acesso_a_datos.Models;

public partial class Conferencium
{
    public int Id { get; set; }

    public string NombreConfe { get; set; } = null!;

    public string Horario { get; set; } = null!;

    public string Fecha { get; set; } = null!;

    public string Conferencista { get; set; } = null!;

    public virtual ICollection<Registro>? Registros { get; set; } = new List<Registro>();
}
