using Clientes.DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services.Interfaces
{
    public interface IClientService
    {
        Task<ClientDto?> ObtenerPorIdentificacionAsync(string identificacion, CancellationToken ct = default);
    }
}
