using CMS.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.Comments.args;

public class ModifyCommentArg
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public bool IsApprove { get; set; }
    public Content content { get; set; }
    public long ParentId { get; set; }
}
