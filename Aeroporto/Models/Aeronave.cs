using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Aeronave
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public int NumeroAssento { get; set; }

    public virtual ICollection<Poltrona> Assento { get; set; } = new List<Poltrona>();

    public virtual ICollection<Voo> Voos { get; set; } = new List<Voo>();
}
