using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;
using webapi.Interfaces;
using System.Xml;
using webapi.Data;
using Microsoft.EntityFrameworkCore;

namespace webapi.Repository{
    public class StockRepository: IStockRepository{
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context){
              _context=context;
        }
        public Task<List<Stock>> GetAllSync(){
            return _context.Stock.ToListAsync();
        }
    }
}