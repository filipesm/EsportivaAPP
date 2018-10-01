using System;
using System.Collections.Generic;
using System.Text;
using App2.Layers.Service;
using App2.Model;

namespace App2.Layers.Business
{
    public class TimeBusiness
    {
        public void SaveTime(TimeModel timeModel)
        {
            new TimeService().SaveTimeOnSalesForce(timeModel);
        }
    }
}
