using System;
using System.Collections.Generic;

namespace Act1_U2.Models.Entities;

public partial class Clase
{
    public int Idclase { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Especies> Especies { get; set; } = new List<Especies>();
}
