using App2.Model;
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
            var uri = "https://na49.salesforce.com/services/data/v43.0/sobjects/Time__c/a015A00000kEv6SQAS/Jogadores__r";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.TokenSalesForce.access_token);

            var resposta = client.GetAsync(uri).Result;

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
        public void SaveJogadoresOnSalesForce(JogadorSalesForceModel jogadorSalesForce)
        {
            var _urlAccountApi = "https://na49.salesforce.com/services/data/v43.0/sobjects/Jogador__c";

            var arrayData = jogadorSalesForce.Data_de_nascimento__c.Split('/');

            jogadorSalesForce.Data_de_nascimento__c = arrayData[2] + "-" + arrayData[1] + "-" + arrayData[0];

            var _body = JsonConvert.SerializeObject(jogadorSalesForce);

            StringContent _conteudo = new StringContent(_body, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.TokenSalesForce.access_token);
            var response = client.PostAsync(_urlAccountApi, _conteudo).Result;

            if (response.IsSuccessStatusCode)
            {
                var conteudoResposta = response.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(conteudoResposta);
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }
    }
}
