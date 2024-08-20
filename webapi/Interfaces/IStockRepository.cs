using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Interfaces{
    public interface IStockRepository{
        Task<List<Stock>> GetAllSync();
    }
}