using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.DTO.Stock
{
    public class StockDto{
        public int Id {get; set;}
        public string companyName{get; set;}=string.Empty;
        public string symbol{get; set;}=string.Empty;

        public decimal purchase{get; set;}
 
        public decimal lastDiv{get; set;}

        public string Industry{get; set;}=string.Empty;

        public long marketCap{get; set;}

    }
    
}