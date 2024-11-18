using FinHub.API.Converters;
using FinHub.API.Requests;
using FinHub.Gastos.Domain.Transacoes.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace finhub_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacaoController(ICentralGastosService centralGastosService) : Controller
    {
        private readonly ICentralGastosService centralGastosService = centralGastosService;

        [HttpPost]
        public IActionResult RecebeTransacao([FromBody] TransacaoRequest transacaoRequest)
        {
            if (transacaoRequest == null)
            {
                return BadRequest("O payload não pode ser vazio.");
            }

            try
            {
                var transacaoDTODomain = new TransacaoConverter().ToTransacaoDomain(transacaoRequest);

                return Ok(centralGastosService.ProcessarGasto(transacaoDTODomain));
            }
            catch (Exception ex)
            {
                // Trata erros inesperados
                return StatusCode(500, $"Erro ao processar a transação: {ex.Message}");
            }
        }
    }
}