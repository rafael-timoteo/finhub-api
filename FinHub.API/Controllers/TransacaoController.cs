using FinHub.API.Requests;
using Microsoft.AspNetCore.Mvc;

namespace finhub_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacaoController : Controller
    {
        [HttpPost]
        public IActionResult RecebeTransacao([FromBody] TransacaoRequest transacao)
        {
            if (transacao == null)
            {
                return BadRequest("O payload não pode ser vazio.");
            }

            return Ok(new { Message = "Transação recebida com sucesso!"});
        }
    }
}