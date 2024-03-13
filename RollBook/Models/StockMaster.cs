using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RollBook.Models
{
    public class StockMaster
    {
        public string Size { get; set; }
        public string DNR { get; set; }
        public string QualityName { get; set; }
        public float Quantity { get; set; }
        public int LoomNo { get; set; }
    }
}