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
using Microsoft.AspNetCore.Mvc;

namespace webapi.Repository{
    public class CommentRepository: ICommentRepository{
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
         _context=context;   
        }
        public async Task<List<Comment>> GetAllAsync(){
            return await _context.Comment.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comment.FindAsync(id);
        }
      
    }
}