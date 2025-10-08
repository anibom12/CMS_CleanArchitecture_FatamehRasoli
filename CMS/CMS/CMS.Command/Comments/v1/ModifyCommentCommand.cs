using CMS.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Command.Comments.v1;

public class ModifyCommentCommand:IRequest<long>
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public bool IsApprove { get; set; }
    public Content content { get; set; }
    public long ParentId { get; set; }
}
