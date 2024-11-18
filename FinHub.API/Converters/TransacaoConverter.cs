using FinHub.API.Requests;
using FinHub.Domain.Models;

namespace FinHub.API.Converters
{
    public class TransacaoConverter
    {
        public Transacao ToTransacaoDomain(TransacaoRequest transacaoRequest)
        {
            return new Transacao
            {
                Cliente = new Cliente
                {
                    Nome = transacaoRequest.Creditor.Name,
                    Cpf = transacaoRequest.Creditor.CpfCnpj,
                    NumeroContaBancaria = transacaoRequest.Payment.Details.CreditorAccount.Number
                },
                Pagamento = new Pagamento
                {
                    TipoPagamento = ToTipoPagamento(transacaoRequest.Payment.Type),
                    Data = transacaoRequest.Payment.Date,
                    Valor = transacaoRequest.Payment.Amount,
                    NumeroContaBancaria = transacaoRequest.Payment.Details.CreditorAccount.Number
                },
                Estabelecimento = new Estabelecimento
                {
                    Cnpj = transacaoRequest.BusinessEntity.Document.Identification
                }
            };
        }

        public TipoPagamento ToTipoPagamento(string tipoPagamento)
        {
            return tipoPagamento switch
            {
                "PIX" => TipoPagamento.Pix,
                "CREDITO" => TipoPagamento.Credito,
                "DEBITO" => TipoPagamento.Debito,
                _ => throw new Exception("Tipo de pagamento não reconhecido")
            };
        }
    }
}