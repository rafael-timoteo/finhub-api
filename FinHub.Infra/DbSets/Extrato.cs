namespace FinHub.Infra.DbSets
{
    public class Extrato
    {
        public string ClienteCPF { get; set; }
        public string NumeroConta { get; set; }
        public string NomeEmpresa { get; set; }
        public DateTime DataTransacao { get; set; }
        public decimal ValorTransacao { get; set; }
        public string Classificacao { get; set; }
    }

}