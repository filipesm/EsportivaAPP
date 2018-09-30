using App2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace App2.Layers.Service
{
    public class JogadoresService
    {
        public IList<DateModel> GetJogadoresFromSalesForce()
        {
            var uri = "https://www.reqres.in/api/unknown";

            HttpClient client = new HttpClient();
            var resposta = client.GetAsync(uri).Result;

            if (resposta.IsSuccessStatusCode)
            {
                var resultado = resposta.Content.ReadAsStringAsync().Result;
                var jogadores = JsonConvert.DeserializeObject<JogadoresModel>(resultado);

                return jogadores.Data;
            }
            else
            {
                throw new Exception("Perfis não encontrados!");
            }


        }
    }
}
