using App2.Model;
using App2.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace App2.Layers.Service
{
    public class JogadoresService
    {
        public string GetJogadoresFromSalesForce()
        {
            var _urlAccountApi = $"https://na49.salesforce.com/services/data/v43.0/sobjects/Time__c/{Global.TimeId}/Jogadores__r";

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
                throw new Exception("Não foi possivel trazer os jogadores!");
            }


        }
        public string SaveJogadoresOnSalesForce(JogadorSalesForceModel jogadorSalesForce)
        {
            var _urlAccountApi = "https://na49.salesforce.com/services/data/v43.0/sobjects/Jogador__c";

            jogadorSalesForce.Data_de_nascimento__c = DateConverter.ConvertDateToSalesForce(jogadorSalesForce.Data_de_nascimento__c);

            jogadorSalesForce.Time__c = Global.TimeId;

            var _body = JsonConvert.SerializeObject(jogadorSalesForce);

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

        public void UpdateJogadorOnSalesForce(JogadorSalesForceModel jogadorSalesForceModel)
        {
            var _urlAccountApi = $"https://na49.salesforce.com/services/data/v43.0/sobjects/Jogador__c/{jogadorSalesForceModel.Id}";

            var _body = JsonConvert.SerializeObject(
                new
                {
                    jogadorSalesForceModel.Apelido__c,
                    Numero_na_camisa__c = jogadorSalesForceModel.Numero_na_camisa__c.ToString(),
                    jogadorSalesForceModel.Posicao__c
                });

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.TokenSalesForce.access_token);

            StringContent _conteudo = new StringContent(_body, Encoding.UTF8, "application/json");

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(client.BaseAddress + _urlAccountApi),
                Content = _conteudo,
            };

            var response = client.SendAsync(request);
            var result = response.Result;
        }

        public void DeleteJogadorOnSalesForce(string id)
        {
            var _urlAccountApi = $"https://na49.salesforce.com/services/data/v43.0/sobjects/Jogador__c/{id}";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.TokenSalesForce.access_token);

            var response = client.DeleteAsync(_urlAccountApi);

            var result = response.Result;

        }


    }
}




