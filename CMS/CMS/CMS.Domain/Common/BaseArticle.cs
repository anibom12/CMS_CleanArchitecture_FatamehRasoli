using CMS.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Common;

public abstract class BaseArticle
{
    public long UserId { get; set; }
    public string Title { get; set; }
    public string URL { get; set; }
    public DateTime PublishDate { get; set; }

    public ValueObjects.Content content { get; set; }
}
