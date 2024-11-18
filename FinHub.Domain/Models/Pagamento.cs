namespace FinHub.Domain.Models
{
    public class Pagamento
    {
        public TipoPagamento TipoPagamento { get; set; }

        public DateTime Data { get; set; }

        public decimal Valor { get; set; }

        public string NumeroContaBancaria { get; set; }
    }

    public enum TipoPagamento
    {
        Pix,

        Credito,

        Debito
    }
}