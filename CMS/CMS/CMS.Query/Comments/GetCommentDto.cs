using CMS.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Query.Comments;

public class GetCommentDto
{
    public long Id { get; set; }
   
    public Content content { get; set; }
  
    public GetCommentDto() { }
}
