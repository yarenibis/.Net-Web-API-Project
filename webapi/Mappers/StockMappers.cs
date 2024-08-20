using System;
using System.Linq;
using System.Threading.Tasks;
using webapi.DTO.Stock;
using webapi.Models;
using System.Collections.Generic;
namespace webapi.Mappers{
    public static class StockMappers{
        //bir Stock model nesnesini, StockDto nesnesine dönüştüren bir genişletme metodu
       public static StockDto toStockDto(this Stock stockModel){
          return new StockDto{
              Id= stockModel.Id,
              symbol=stockModel.symbol,
              companyName=stockModel.companyName,
              purchase=stockModel.purchase,
              lastDiv=stockModel.lastDiv,
              Industry=stockModel.Industry,
              marketCap=stockModel.marketCap,
              comments=stockModel.comments.Select(c=>c.ToCommentDto()).ToList()
            
          };
          
       }
       public static Stock ToStockFromCreateDTO(this CreateStockRequestDto StockDto){ //CreateStockRequestDto nesnesini Stock model nesnesine dönüştürmek için kullanılan bir mapleme (mapping) metodudur.
           return new Stock{
            symbol=StockDto.symbol,
            companyName=StockDto.companyName,
            purchase=StockDto.purchase,
            lastDiv=StockDto.lastDiv,
            Industry=StockDto.Industry,
            marketCap=StockDto.marketCap
           };
       }
}
}
