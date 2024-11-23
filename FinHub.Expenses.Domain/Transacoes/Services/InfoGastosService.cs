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

                JObject jsonResponse = JObject.Parse(response);
                
                var empresaInfo = jsonResponse.ToObject<EmpresaDTO>();

                return empresaInfo!;
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
                "35" => TipoCNAE.Contas, // Eletricidade e gás
                "36" => TipoCNAE.Contas, // Água
                "37" => TipoCNAE.Contas, // Água
                "38" => TipoCNAE.Contas, // Água
                "39" => TipoCNAE.Contas, // Água
                "41" => TipoCNAE.Contas, // Construção
                "42" => TipoCNAE.Contas, // Construção
                "43" => TipoCNAE.Contas, // Construção
                "61" => TipoCNAE.Contas, // Telecomunicações
                "65" => TipoCNAE.Contas, // SEGUROS, RESSEGUROS, PREVIDÊNCIA COMPLEMENTAR E PLANOS DE SAÚDE
                "66" => TipoCNAE.Contas, // ATIVIDADES AUXILIARES DOS SERVIÇOS FINANCEIROS, SEGUROS, PREVIDÊNCIA COMPLEMENTAR E PLANOS DE SAÚDE
                "68" => TipoCNAE.Contas, // Atividades imobiliárias
                "97" => TipoCNAE.Contas, // Serviços domésticos

                "46" => TipoCNAE.Compras, // Comércio atacado
                "47" => TipoCNAE.Compras, // Comércio varejista

                "49" => TipoCNAE.Transporte, // Transporte terrestre
                "50" => TipoCNAE.Transporte, // Transporte aéreo

                "56" => TipoCNAE.Alimentacao, // Alimentacao

                "59" => TipoCNAE.Entretenimento, // Atividades cinematográficas
                "90" => TipoCNAE.Entretenimento, // Atividades artísticas, criativas e de espetáculos
                "91" => TipoCNAE.Entretenimento, // Atividades ligadas ao patrimônio cultural e ambiental
                "93" => TipoCNAE.Entretenimento, // Atividades esportivas e de recreação e lazer

                "85" => TipoCNAE.Educacao, // Educação

                "86" => TipoCNAE.Saude, // Atividades de atenção à saúde humana
                "75" => TipoCNAE.Saude, // Atividades veterinárias

                _ => TipoCNAE.Outros
            };
        }
    }
}