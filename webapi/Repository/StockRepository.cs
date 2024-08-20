using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;
using webapi.Interfaces;
using System.Xml;
using webapi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace webapi.Repository{
    public class StockRepository: IStockRepository{
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context){
              _context=context;
        }
        public async Task<List<Stock>> GetAllAsync(){
            return await _context.Stock.Include(c=>c.comments).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id){
             return await _context.Stock.Include(c=>c.comments).FirstOrDefaultAsync(i => i.Id ==id);
        }

         public async Task<Stock> CreateAsync(Stock stockModel){
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id){
            var stockModel=await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if(stockModel==null){
                return null;
            }
            _context.Stock.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto){
             var existingStock=await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
             if(existingStock==null){
                return null;
             }
             existingStock.symbol=stockDto.symbol;
             existingStock.companyName=stockDto.companyName;
             existingStock.lastDiv=stockDto.lastDiv;
             existingStock.marketCap=stockDto.marketCap;
             existingStock.purchase=stockDto.purchase;
             existingStock.Industry=stockDto.Industry;

             await _context.SaveChangesAsync();
             return existingStock;
        }
    }
}