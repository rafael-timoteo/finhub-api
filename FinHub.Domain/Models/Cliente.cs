namespace FinHub.Domain.Models
{
    public class Cliente
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public DateTime Nascimento { get; set; }

        public string NumeroContaBancaria { get; set; }
    }
}