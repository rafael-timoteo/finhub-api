using FinHub.API.Converters;
using FinHub.API.DTOs.Requests;
using FinHub.API.Requests;
using FinHub.Gastos.Domain.Transacoes.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace finhub_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CentralGastosController(ICentralGastosService centralGastosService) : Controller
    {
        private readonly ICentralGastosService centralGastosService = centralGastosService;

        [HttpPost("ReceberTransacao")]
        public IActionResult ReceberTransacao([FromBody] TransacaoRequest transacaoRequest)
        {
            if (transacaoRequest == null)
                return BadRequest("O payload não pode ser vazio.");

            try
            {
                var transacaoDTODomain = new TransacaoConverter().ToTransacaoDomain(transacaoRequest);
                centralGastosService.CriarGasto(transacaoDTODomain);
                return Ok("Gasto criado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao processar a transação: {ex.Message}");
            }
        }

        [HttpPost("GetGastosPorClassificacao")]
        public IActionResult GetGastosPorClassificacao([FromBody] GastosPorClassificacaoRequest gastosPorClassificacao)
        {
            if (gastosPorClassificacao == null)
                return BadRequest("O payload não pode ser vazio.");
            try
            {
                var valorGasto = centralGastosService.GetGastoClassificacao(
                                                                            gastosPorClassificacao.ClienteCPF, 
                                                                            gastosPorClassificacao.Classificacao, 
                                                                            gastosPorClassificacao.DataInicio, 
                                                                            gastosPorClassificacao.DataFim);
                return Ok(valorGasto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao processar a transação: {ex.Message}");
            }
        }
    }
}