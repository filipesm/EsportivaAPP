using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using App2.Model;
using App2.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace App2.Layers.Service
{
    public class PartidaService
    {            
        public string SavePartidaOnSalesforce(PartidaModel partidaModel)
        {
            var _urlAccountApi = "https://na49.salesforce.com/services/data/v43.0/sobjects/Partida__c";

            partidaModel.Data_da_partida__c = DateConverter.ConvertDateToSalesForce(partidaModel.Data_da_partida__c);

            partidaModel.Time_1__C = Global.TimeId;

            var _body = JsonConvert.SerializeObject(partidaModel);

            StringContent _conteudo = new StringContent(_body, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.TokenSalesForce.access_token);
            var response = client.PostAsync(_urlAccountApi, _conteudo).Result;

            if (response.IsSuccessStatusCode)
            {
                var conteudoResposta = response.Content.ReadAsStringAsync().Result;
                var id = JsonConvert.DeserializeObject<IdModel>(conteudoResposta);
                return id.Id;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public string GetPartidaFromSalesforce()
        {
            var _urlAccountApi = $"https://na49.salesforce.com/services/data/v43.0/sobjects/Time__c/{Global.TimeId}/Partidas__r";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.TokenSalesForce.access_token);

            var resposta = client.GetAsync(_urlAccountApi).Result;

            if (resposta.IsSuccessStatusCode)
            {
                var resultado = resposta.Content.ReadAsStringAsync().Result;

                return resultado;
            }
            else
            {
                throw new Exception("Perfis não encontrados!");
            }
        }
        public string GetAcontecimentosFromSalesForce()
        {
            var _urlAccountApi = $"https://na49.salesforce.com/services/apexrest/v1/Acontecimento/Partida?idPartida={Global.PartidaId}";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.TokenSalesForce.access_token);

            var resposta = client.GetAsync(_urlAccountApi).Result;

            if (resposta.IsSuccessStatusCode)
            {
                var resultado = resposta.Content.ReadAsStringAsync().Result;

                return resultado;
            }
            else
            {
                throw new Exception("Perfis não encontrados!");
            }

            throw new NotImplementedException();
        }
    }
}
