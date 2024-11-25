using FinHub.Usuario.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace FinHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ExtratoController(IExtratoService extratoService) : Controller
    {
        private readonly IExtratoService extratoService = extratoService;

        [HttpGet("ExtratoConta")]
        public IActionResult ObterContaCorrente(string cpf)
        {
            try
            {
                var contas = extratoService.ObterInformacoesContaCorrente(cpf);
                return Ok(contas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar informações da conta corrente: {ex.Message}");
            }
        }

        [HttpGet("SaldoConta")]
        public IActionResult ObterSaldoConta(string cpf)
        {
            try
            {
                var saldo = extratoService.ObterSaldo(cpf);
                return Ok(saldo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar informações da conta corrente: {ex.Message}");
            }
        }

        [HttpGet("EntradasConta")]
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

        [HttpGet("SaidasConta")]
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
