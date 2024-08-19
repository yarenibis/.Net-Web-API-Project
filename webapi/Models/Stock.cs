using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class Stock{
        public int Id {get; set;}
        public string companyName{get; set;}=string.Empty;
        public string symbol{get; set;}=string.Empty;

        [Column(TypeName ="decimal(18,2)")] //model sınıfındaki bir özelliği veritabanındaki bir sütuna eşlemek için kullanılır
        public decimal purchase{get; set;}//for store money

       [Column(TypeName ="decimal(18,2)")] 
        public decimal lastDiv{get; set;}

        public string Industry{get; set;}=string.Empty;

        public long marketCap{get; set;}

        public List<Comment> comments {get; set;}=new List<Comment>();

    }
    
}