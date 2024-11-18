using FinHub.Gastos.Domain.Transacoes.Interfaces;
using FinHub.Gastos.Domain.Transacoes.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FinHub.Gastos.Domain.Transacoes.Services
{
    public class InfoGastosService : IInfoGastosService
    {
        public async Task<EmpresaDTO> ConsultarCNPJ(string cnpj)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"https://api.cnpjs.dev/v1/{cnpj}";

                var response = await client.GetStringAsync(url);

                JObject jsonResponse = JObject.Parse(response);  // Verifica se a string é JSON válido
                
                var cnpjInfo = jsonResponse.ToObject<EmpresaDTO>();

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

        public TipoCNAE ClassificarCNAE(string cnae)
        {
            string prefixoCNAE = cnae.Substring(0, 2);

            return prefixoCNAE switch
            {
                "35" => TipoCNAE.Eletricidade,
                "36" => TipoCNAE.Agua,
                "47" => TipoCNAE.Comercio,
                "49" => TipoCNAE.Transporte,
                "56" => TipoCNAE.Alimentacao,
                "59" => TipoCNAE.Cultura,
                "85" => TipoCNAE.Educacao,
                "86" => TipoCNAE.Saude,
                "90" => TipoCNAE.Cultura,
                _ => throw new Exception("Não foi possível classificar o CNAE!")
            };
        }
    }
}