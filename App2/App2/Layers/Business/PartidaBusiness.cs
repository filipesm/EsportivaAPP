using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App2.Layers.Service;
using App2.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using App2.Layers.Data;
using System.Globalization;

namespace App2.Layers.Business
{
    public class PartidaBusiness
    {
        public void SavePartida(PartidaModel partidaModel)
        {
            if (!DateTime.TryParseExact(partidaModel.Data_da_partida__c, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                throw new Exception("Informar formato de data válido (dd/MM/yyyy)");

            var id = new PartidaService().SavePartidaOnSalesforce(partidaModel);

            partidaModel.Id = id;

            new PartidaData().Insert(partidaModel);
        }

        public IList<PartidaModel> GetPartida()
        {
            IList<PartidaModel> searchResults = null;

            searchResults = new PartidaData().GetList();

            if (searchResults.Count == 0)
            {
                var partidas = new PartidaService().GetPartidaFromSalesforce();

                JObject jObject = JObject.Parse(partidas);

                IList<JToken> results = jObject["records"].Children().ToList();

                searchResults = new List<PartidaModel>();

                foreach (var result in results)
                {
                    PartidaModel searchResult = result.ToObject<PartidaModel>();
                    searchResults.Add(searchResult);

                    new PartidaData().Insert(searchResult);
                }
            }
            return searchResults;
        }

        public IList<AcontecimentosModel> GetAcontecimentos()
        {

            var acontecimentos = new PartidaService().GetAcontecimentosFromSalesForce();

            return JsonConvert.DeserializeObject<List<AcontecimentosModel>>((JToken.Parse(acontecimentos)).ToString());
        }
    }
}
