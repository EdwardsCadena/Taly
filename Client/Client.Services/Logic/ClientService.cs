using Client.Repositories.Interfaces;
using Client.Services.Interfaces;
using Clientes.DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services.Logic
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repo;

        public ClientService(IClientRepository repo) => _repo = repo;

        public async Task<ClientDto?> ObtenerPorIdentificacionAsync(string identificacion, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(identificacion))
                return null;

            var entity = await _repo.ObtenerPorIdentificacionAsync(identificacion.Trim(), ct);
            if (entity is null) return null;

            return new ClientDto
            {
                ClienteId = entity.ClienteId,
                Identificacion = entity.Identificacion,
                Nombres = entity.Nombres,
                Apellidos = entity.Apellidos,
                Email = entity.Email,
                Telefono = entity.Telefono,
                FechaRegistro = entity.FechaRegistro,
                Activo = entity.Activo
            };
        }
    }
}
