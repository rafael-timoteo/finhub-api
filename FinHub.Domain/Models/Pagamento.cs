namespace FinHub.Domain.Models
{
    public class Pagamento
    {
        public DateTime Data { get; set; }

        public decimal Valor { get; set; }

        public TipoPagamento TipoPagamento { get; set; }

        public int UltimosDigitosCartao { get; set; }
    }

    public enum TipoPagamento
    {
        Pix,

        Credito,

        Debito
    }
}