using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Escala
{
    public int Id { get; set; }

    public int? VooId { get; set; }

    public string AeroportoSaida { get; set; } = null!;

    public DateTime HorarioSaida { get; set; }

    public virtual Voo? Voo { get; set; }
}
