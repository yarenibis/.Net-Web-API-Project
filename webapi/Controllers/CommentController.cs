using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapi.Mappers;
using webapi.Interfaces;



namespace webapi.Controllers{
    [Route("webapi/comment")] 
    [ApiController]
    public class CommentController: ControllerBase{

       private readonly ICommentRepository _commentrepo;
       public CommentController(ICommentRepository commentrepo){
        _commentrepo=commentrepo;
       }
       
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var comment=await _commentrepo.GetAllAsync();
            var commentDto=comment.Select(s =>s.ToCommentDto());

            return Ok(commentDto);
        }


        [HttpGet("{id}")]
         public async Task<IActionResult> GetById([FromRoute] int id){
           var comment=await _commentrepo.GetByIdAsync(id);
           if(comment==null){
            return NotFound();
           }
           return Ok(comment.ToCommentDto());
        }
       }

    }
