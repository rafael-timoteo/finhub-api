namespace FinHub.Gastos.Domain.Transacoes.Models
{
    public class Gasto
    {
        public string Descricao { get; set; }

        public DateTime Data { get; set; }

        public decimal Valor { get; set; }

        public string Classificacao { get; set; }
    }
}