namespace FinHub.API.DTOs.Requests
{
    public class GastosPorContaRequest
    {
        public string ClienteCPF { get; set; }

        public string Conta { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }
    }
}