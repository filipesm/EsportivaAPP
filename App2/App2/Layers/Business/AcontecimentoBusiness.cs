using App2.Layers.Service;
using App2.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App2.Layers.Business
{
    public class AcontecimentoBusiness
    {
        
        public List<ListAcontecimentoModel> GetAcontecimento()
        {
            var acontecimentos = new AcontecimentoService().GetAcontecimentosFromSalesforce();

            JObject jObject = JObject.Parse(acontecimentos);

            IList<JToken> results = jObject["recentItems"].Children().ToList();

            IList<ListAcontecimentoModel> searchResults = new List<ListAcontecimentoModel>();

            foreach (var result in results)
            {
                ListAcontecimentoModel searchResult = result.ToObject<ListAcontecimentoModel>();
                searchResults.Add(searchResult);
            }

            return searchResults.ToList();
        }
    }
}
