using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Common;

public abstract class BaseCT:BaseEntity
{
    public string Name { get; set; }
    public string URl { get; set; }
    public long ParentId { get; set; }



}
