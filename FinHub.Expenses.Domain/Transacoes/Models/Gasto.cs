namespace FinHub.Gastos.Domain.Transacoes.Models
{
    /// <summary>
    /// Definição do objeto do gasto da transação financeira.
    /// </summary>
    public class Gasto
    {
        /// <summary>
        /// Descrição do gasto
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Data do gasto
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Valor do gasto
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Classificacao do gasto
        /// </summary>
        public string Classificacao { get; set; }
    }
}