using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Model
{
    public class TimeResponseModel
    {
        public string Id { get; set; }
        public bool Success { get; set; }
        public List<object> Errors { get; set; }
    }
}
