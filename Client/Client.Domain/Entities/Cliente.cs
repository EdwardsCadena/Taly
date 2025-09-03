using System;
using System.Collections.Generic;

namespace Client.Domain.Entities;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string Identificacion { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public DateTime FechaRegistro { get; set; }

    public bool Activo { get; set; }
}
