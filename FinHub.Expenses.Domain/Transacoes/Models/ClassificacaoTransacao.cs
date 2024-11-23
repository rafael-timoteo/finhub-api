namespace FinHub.Gastos.Domain.Transacoes.Models
{
    /// <summary>
    /// Definição dos tipos de classificação de transações tratadas.
    /// </summary>
    public enum ClassificacaoTransacao
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
        /// Valor creditado na conta.
        /// </summary>
        Entrada,

        /// <summary>
        /// Outros tipos de gastos.
        /// </summary>
        Outros
    }
}