using CMS.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Command.Comments.v1;

public class RemoveCommentCommand:IRequest<long>
{
    public long Id { get; set; }
    public long UserId { get; set; }
    
}
