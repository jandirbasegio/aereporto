using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Voo
{
    public int Id { get; set; }

    public string AeroportoOrigem { get; set; } = null!;

    public string AeroportoDestino { get; set; } = null!;

    public DateTime HorarioSaida { get; set; }

    public DateTime HorarioPrevistoChegada { get; set; }

    public int? AeronaveId { get; set; }

    public virtual Aeronave? Aeronave { get; set; }

    public virtual ICollection<Escala> Escalas { get; set; } = new List<Escala>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
