using FinHub.Gastos.Domain.Transacoes.Interfaces;
using FinHub.Gastos.Domain.Transacoes.Models;
using Newtonsoft.Json;

namespace FinHub.Gastos.Domain.Transacoes.Services
{
    public class InfoGastosService : IInfoGastosService
    {
        public async Task<Cnpj> ConsultarCNPJ(string cnpj)
        {
            using var client = new HttpClient();
            try
            {
                // URL da API com o CNPJ
                string url = $"https://api.cnpjs.dev/v1/{cnpj}";

                // Enviar a solicitação GET para a API
                var response = await client.GetStringAsync(url);

                // Deserializar a resposta JSON para o objeto CnpjInfo
                var cnpjInfo = JsonConvert.DeserializeObject<Cnpj>(response);

                return cnpjInfo!;
            }
            catch (HttpRequestException e)
            {
                throw new Exception($"Erro na requisição: {e.Message}");
            }
            catch (JsonException e)
            {
                throw new Exception($"Erro ao processar os dados: {e.Message}");
            }
        }

        public TipoCNAE ClassificarCNAE(Cnpj cnpj)
        {
            if (cnpj.CNAE == null)
                throw new Exception("Não foi possível classificar o CNAE!");

            string prefixoCNAE = cnpj.CNAE.Substring(0, 2);

            return prefixoCNAE switch
            {
                "35" => TipoCNAE.Eletricidade,
                "36" => TipoCNAE.Agua,
                "47" => TipoCNAE.Comercio,
                "49" => TipoCNAE.Transporte,
                "56" => TipoCNAE.Alimentacao,
                "85" => TipoCNAE.Educacao,
                "86" => TipoCNAE.Saude,
                "90" => TipoCNAE.Cultura,
                _ => throw new Exception($"CNAE de prefixo: {prefixoCNAE} não existe ou não há classificação")
            };
        }
    }
}