using Client.Domain.Entities;
using Client.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Client.Repositories.Interfaces
{
    public class ClientRepository : IClientRepository
    {
        private readonly DbclientesContext _ctx;

        public ClientRepository(DbclientesContext ctx) => _ctx = ctx;

        public async Task<Cliente?> ObtenerPorIdentificacionAsync(string identificacion, CancellationToken ct = default)
        {
            var cliente = await _ctx.Clientes
            .FromSqlInterpolated($"EXEC dbo.sp_ObtenerClientePorIdentificacion {identificacion}")
            .ToListAsync();

            return cliente.FirstOrDefault();
        }
    }
}
