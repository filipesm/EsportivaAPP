using App2.Layers.Service;
using App2.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App2.Layers.Business
{
    public class JogadoresBusiness
    {
        public IList<JogadorSalesForceModel> GetJogadores()
        {
            var jogadores = new JogadoresService().GetJogadoresFromSalesForce();

            JObject jObject = JObject.Parse(jogadores);

            IList<JToken> results = jObject["records"].Children().ToList();

            IList<JogadorSalesForceModel> searchResults = new List<JogadorSalesForceModel>();

            foreach (var result in results)
            {
                JogadorSalesForceModel searchResult = result.ToObject<JogadorSalesForceModel>();
                searchResults.Add(searchResult);
            }

            return searchResults;
        }

        public void SaveJogador(JogadorSalesForceModel jogadorSalesForce)
        {
            new JogadoresService().SaveJogadoresOnSalesForce(jogadorSalesForce);
        }
    }
}
