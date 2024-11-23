namespace FinHub.Domain.Models
{
    /// <summary>
    /// Definição do objeto de Cliente.
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Nome do cliente.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// CPF do cliente.
        /// </summary>
        public string Cpf { get; set; }

        /// <summary>
        /// Data de nascimento do cliente.
        /// </summary>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Numero da conta bancária do cliente.
        /// </summary>
        public string NumeroContaBancaria { get; set; }
    }
}