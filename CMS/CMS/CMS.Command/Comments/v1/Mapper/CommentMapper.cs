using CMS.Command.Users.v1;
using CMS.Domain.Entity.Comments.args;
using CMS.Domain.Entity.User.args;
using CMS.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Command.Comments.v1.Mapper;

public class CommentMapper
{
    public static RegisterCommentArg Map(RegisterCommentCommand CommentCommand)
    {
        return new RegisterCommentArg
        {
            Id = CommentCommand.Id,
            UserId = CommentCommand.UserId,
            content = CommentCommand.content


        };
    }
   
    public static ModifyCommentArg Map(ModifyCommentCommand CommentCommand)
    {
        return new ModifyCommentArg
        {
            Id = CommentCommand.Id,
            UserId = CommentCommand.UserId,
            content = CommentCommand.content
        

        };
    }
}
