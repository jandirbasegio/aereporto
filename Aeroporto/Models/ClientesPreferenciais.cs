using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class ClientesPreferenciais
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public DateOnly DataNascimento { get; set; }

    public string? Gestante { get; set; }

    public string? Idoso { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
