using System;
using System.Collections.Generic;

namespace Acesso_a_datos.Models;

public partial class Participante
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Twitter { get; set; } = null!;

    public string Avatar { get; set; } = null!;

    public virtual ICollection<Registro>? Registros { get; set; } = new List<Registro>();
}
