using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using App2.Model;
using Newtonsoft.Json;

namespace App2.Layers.Service
{
    public class TimeService
    {
        /// <summary>
        /// Salva o time na sales force
        /// </summary>
        /// <param name="timeModel">Time a ser cadastrado</param>
        public void SaveTimeOnSalesForce(TimeModel timeModel)
        {
            var _urlAccountApi = "https://na49.salesforce.com/services/data/v43.0/sobjects/Time__c";

            var arrayData = timeModel.Data_De_Fundacao__c.Split('/');

            timeModel.Data_De_Fundacao__c = arrayData[2] + "-" + arrayData[1] + "-" + arrayData[0];

            var _body = JsonConvert.SerializeObject(timeModel);

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
