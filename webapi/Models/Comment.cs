using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class Comment{
       public int Id{get; set;}

       public string title{get; set;}=string.Empty;
       public string content{get; set;}=string.Empty;
       public DateTime createdOn{get; set;}=DateTime.Now;
       public int? StockId{get; set;}
       //navigation
       public Stock? Stock{get; set;} //bir Comment kaydının hangi Stock kaydıyla ilişkili olduğunu temsil eder

    }
    
}