namespace FinHub.Domain.Models
{
    public class Transacao
    {
        public Cliente Cliente { get; set; }

        public Pagamento Pagamento { get; set; }

        public Estabelecimento Estabelecimento { get; set; }
    }
}