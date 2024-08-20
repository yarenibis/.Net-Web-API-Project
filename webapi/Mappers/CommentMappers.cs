using System;
using System.Linq;
using System.Threading.Tasks;
using webapi.DTO.Comment;
using webapi.Models;

namespace webapi.Mappers{
    public static class CommentMappers{
     public static CommentDto ToCommentDto(this Comment commentModel){
        return new CommentDto{
            Id=commentModel.Id,
            title=commentModel.title,
            content=commentModel.content,
            createdOn=commentModel.createdOn,
            StockId=commentModel.StockId
        };
     }
      
}
}