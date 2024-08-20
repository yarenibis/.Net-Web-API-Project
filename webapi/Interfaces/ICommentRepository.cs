using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Interfaces{
    public interface ICommentRepository{
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);

    }
}