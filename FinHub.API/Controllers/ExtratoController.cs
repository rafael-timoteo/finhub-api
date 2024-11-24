using FinHub.Usuario.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace finhub_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ExtratoController(IExtratoService extratoService) : Controller
    {
        private readonly IExtratoService extratoService = extratoService;

        [HttpGet("extrato-conta")]
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
    }
}
