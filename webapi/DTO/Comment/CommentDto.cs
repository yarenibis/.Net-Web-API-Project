using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.DTO.Comment
{
    public class CommentDto{
       public int Id{get; set;}

       public string title{get; set;}=string.Empty;
       public string content{get; set;}=string.Empty;
       public DateTime createdOn{get; set;}=DateTime.Now;
       public int? StockId{get; set;}
       //navigation

    }
    
}