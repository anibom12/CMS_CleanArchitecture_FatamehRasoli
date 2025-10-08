using CMS.Domain.Common;
using CMS.Domain.Entity.Comments.args;
using CMS.Domain.Entity.User;
using CMS.Domain.ValueObjects;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.Comments;

public class Comment:BaseEntity
{
   
    public bool IsApprove { get; set; }
    public Content content { get; set; }


    public long UserId { get; set; }
   
    private Comment() { }
    private Comment(RegisterCommentArg arg)
    {
        Id = arg.Id;
        content = arg.content;
       
      
    }
    public static async Task<Comment> New (RegisterCommentArg arg,ICommentService service,CancellationToken token)
    {
        return new Comment(arg);
    }
    public async Task Modify(ModifyCommentArg arg, IUserService service, CancellationToken token)
    {
        
        content = arg.content??content;
    }
    public void Approve()
    {
        IsApprove = true;
    }
    public void Remove()
    {
        IsDeleted = true;
    }
}
