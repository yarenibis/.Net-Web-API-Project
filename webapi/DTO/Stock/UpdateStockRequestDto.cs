using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



    public class UpdateStockRequestDto{

        public string companyName{get; set;}=string.Empty;
        public string symbol{get; set;}=string.Empty;

        public decimal purchase{get; set;}//for store money

        public decimal lastDiv{get; set;}

        public string Industry{get; set;}=string.Empty;

        public long marketCap{get; set;}


    }
    
