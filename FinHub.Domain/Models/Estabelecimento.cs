namespace FinHub.Domain.Models
{
    /// <summary>
    /// Definição do objeto estabelecimento.
    /// </summary>
    public class Estabelecimento
    {
        /// <summary>
        /// Nome da empresa que recebeu o pagamento.
        /// </summary>
        public string NomeEmpresa { get; set; }

        /// <summary>
        /// CNPJ da empresa que recebeu o pagamento.
        /// </summary>
        public string Cnpj { get; set; }
    }
}