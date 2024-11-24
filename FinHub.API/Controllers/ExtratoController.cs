using FinHub.Usuario.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace finhub_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ExtratoController(IExtratoService extratoService) : Controller
    {
        private readonly IExtratoService extratoService = extratoService;

        [HttpPost("ExtratoConta")]
        public IActionResult ObterContaCorrente(string numeroConta)
        {
            try
            {
                var contas = extratoService.ObterInformacoesContaCorrente(numeroConta);
                return Ok(contas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar informações da conta corrente: {ex.Message}");
            }
        }

        [HttpPost("SaldoConta")]
        public IActionResult ObterSaldoConta(string cpf)
        {
            try
            {
                var saldo = extratoService.ObterSaldo(cpf);
                return Ok($"Saldo: {saldo}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar informações da conta corrente: {ex.Message}");
            }
        }

        [HttpPost("EntradasConta")]
        public IActionResult ObterEntradas(string cpf)
        {
            try
            {
                var entradas = extratoService.ObterEntradas(cpf);
                return Ok(entradas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar informações da conta corrente: {ex.Message}");
            }
        }

        [HttpPost("SaidasConta")]
        public IActionResult ObterSaidas(string cpf)
        {
            try
            {
                var saidas = extratoService.ObterSaidas(cpf);
                return Ok(saidas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar informações da conta corrente: {ex.Message}");
            }
        }
    }
}
