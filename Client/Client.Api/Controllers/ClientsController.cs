using AutoMapper;
using Client.Api.Response;
using Client.Services.Interfaces;
using Client.Services.Logic;
using Clientes.DTOs.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;
        private readonly IMapper _mapper;

        public ClientsController(IClientService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        /// Obtiene los datos de un cliente por su número de identificación.
 
        [HttpGet("{identificacion}")]
        
        public async Task<IActionResult> GetByIdentificacion([FromRoute] string identificacion, CancellationToken ct)
        {
            var cliente = await _service.ObtenerPorIdentificacionAsync(identificacion, ct);

            if (cliente is null)
            {
                return NotFound(new ApiResponse<ClientDto>(null, false, "Cliente no encontrado"));
            }

            var clienteDto = _mapper.Map<ClientDto>(cliente);
            return Ok(new ApiResponse<ClientDto>(clienteDto));
        }
    }
}
