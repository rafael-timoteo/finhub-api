namespace FinHub.Gastos.Domain.Transacoes.Models
{
    /// <summary>
    /// Definição dos tipos de classificação de CNAES tratados.
    /// </summary>
    public enum ClassificacaoCNAE
    {
        /// <summary>
        /// Gastos com contas.
        /// </summary>
        Contas,
        /// <summary>
        /// Gastos com compras no geral.
        /// </summary>
        Compras,

        /// <summary>
        /// Gastos com transporte.
        /// </summary>
        Transporte,

        /// <summary>
        /// Gastos com alimentação.
        /// </summary>
        Alimentacao,

        /// <summary>
        /// Gastos com educação.
        /// </summary>
        Educacao,

        /// <summary>
        /// Gastos com saude.
        /// </summary>
        Saude,

        /// <summary>
        /// Gastos com lazer e entretenimento.
        /// </summary>
        Entretenimento,

        /// <summary>
        /// Outros tipos de gastos.
        /// </summary>
        Outros
    }
}