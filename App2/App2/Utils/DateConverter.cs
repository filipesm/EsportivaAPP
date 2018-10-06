using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Utils
{
    public static class DateConverter
    {
        public static string ConvertDateToSalesForce(string date)
        {
            var arrayData = date.Split('/');

            return arrayData[2] + "-" + arrayData[1] + "-" + arrayData[0];
        }
    }
}
