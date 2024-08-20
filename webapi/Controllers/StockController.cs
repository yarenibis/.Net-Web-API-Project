using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using webapi.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using webapi.Interfaces;


//Bu API, "stok" (Stock) verilerini almak için iki GET HTTP isteği sağlayan basit bir RESTful kontrolcüsüdür. 

namespace webapi.Controllers{
    [Route("webapi/stock")] /* [Route("webapi/stock")]: Bu attribute, kontrolcünün hangi URL yolu üzerinden erişileceğini belirler. Bu durumda, kontrolcüye erişmek için webapi/stock yolunu kullanırsınız. Örneğin, http://localhost:5089/webapi/stock.*/
    [ApiController] //Bu attribute, sınıfın bir Web API kontrolcüsü olduğunu belirtir ve bazı otomatik davranışlar (örneğin, model doğrulama ve hata işleme) ekler.
   
    public class StockController: ControllerBase{

       private readonly ApplicationDBContext _context; //Kontrolcünün içinde veritabanıyla etkileşimde bulunmak için kullanılır.
       private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDBContext context, IStockRepository stockRepo)
       {
        _stockRepo=stockRepo;
        _context=context;
        
       }
       [HttpGet]//İstemciden gelen POST isteği bu metoda yönlendirilir.
       public async Task<IActionResult> GetAll(){  //listeleme kodu

        var stocks=await _stockRepo.GetAllSync();

        var dto=stocks.Select(s =>s.toStockDto());//.Select(s => s.toStockDto()) ifadesi, her Stock model nesnesini StockDto nesnesine dönüştürür. Bu, Stock modelini API yanıtı için daha uygun bir formata getirir.
        return Ok(stocks);
       }


      /*  [HttpGet("{id}")]
       public IActionResult GetById([FromRoute] int id){
           var stock=_context.Stock.Find(id);
           if(stock==null){
            return NotFound();
           }
           return Ok(stock.toStockDto());
       } */


        [HttpGet("{id}")]
       public async Task<IActionResult> GetById([FromRoute] int id){
           var stock=await _context.Stock.FindAsync(id);
           if(stock==null){
            return NotFound();
           }
           return Ok(stock.toStockDto());
       }


       [HttpPost]
       public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto){
           var stockModel=stockDto.ToStockFromCreateDTO();  
           await _context.Stock.AddAsync(stockModel);  //_context.Stock, Stock modelinin veritabanındaki temsilcisidir (bir tabloya karşılık gelir)
           await _context.SaveChangesAsync();
           return CreatedAtAction(nameof(GetById), new { id = stockModel.Id}, stockModel.toStockDto());
       }

       [HttpPut]
       [Route("{id}")]
       public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto){
          var stockModel=await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
          if(stockModel==null){
            return NotFound();
          }
          stockModel.symbol=updateDto.symbol;
          stockModel.companyName=updateDto.companyName;
          stockModel.lastDiv=updateDto.lastDiv;
          stockModel.marketCap=updateDto.marketCap;
          stockModel.purchase=updateDto.purchase;
          stockModel.Industry=updateDto.Industry;

          await _context.SaveChangesAsync();
          return Ok(stockModel.toStockDto());
       }



       [HttpDelete]
       [Route("{id}")]
       public async Task<IActionResult> Delete([FromRoute] int id){
           var stockModel=await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
           if(stockModel==null){
            return NotFound();
          }
          _context.Stock.Remove(stockModel); //!!!!!!!asenkron bi metot değil
          await _context.SaveChangesAsync();
          return NoContent();
       }

    }
}