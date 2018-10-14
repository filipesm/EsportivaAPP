using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using App2.Layers.Service;
using App2.Model;
using Newtonsoft.Json;

namespace App2.Layers.Business
{
    public class TimeBusiness
    {
        public string SaveTime(TimeModel timeModel)
        {
            if (!DateTime.TryParseExact(timeModel.Data_De_Fundacao__c, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                throw new Exception("Informar formato de data válido (dd/MM/yyyy)");

            return new TimeService().SaveTimeOnSalesForce(timeModel);
        }

        public DetalhesTimeModel GetDetalheTime()
        {
            var dados = new TimeService().GetDetalhesTimeSalesForce();
            DetalhesTimeModel detalhes = dados.ToObject<DetalhesTimeModel>();            

            return detalhes;
        }
    }
}
