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
    public class TimeService
    {

        public string SaveTimeOnSalesForce(TimeModel timeModel)
        {
            var _urlAccountApi = "https://na49.salesforce.com/services/data/v43.0/sobjects/Time__c";

            timeModel.Data_De_Fundacao__c = DateConverter.ConvertDateToSalesForce(timeModel.Data_De_Fundacao__c);

            var _body = JsonConvert.SerializeObject(timeModel);

            StringContent _conteudo = new StringContent(_body, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.TokenSalesForce.access_token);
            var response = client.PostAsync(_urlAccountApi, _conteudo).Result;

            if (response.IsSuccessStatusCode)
            {
                var conteudoResposta = response.Content.ReadAsStringAsync().Result;

                var json = JsonConvert.DeserializeObject<TimeResponseModel>(conteudoResposta);

                return json.Id;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public JObject GetDetalhesTimeSalesForce()
        {
            var _urlAccountApi = $"https://na49.salesforce.com/services/apexrest/v1/acontecimentoTime?id={Global.TimeId}";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.TokenSalesForce.access_token);

            var resposta = client.GetAsync(_urlAccountApi).Result;

            if (resposta.IsSuccessStatusCode)
            {
                var resultado = resposta.Content.ReadAsStringAsync().Result;

                JToken token = JToken.Parse(resultado);

                return JObject.Parse((string)token);
            }
            else
            {
                throw new Exception("Não foi possivel trazer os detalhes!");
            }


        }
    }
}
