using CMS.Domain.Common;
using CMS.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.ValueObjects;

public class Content: ValueObject
{

    public string Text { get; set; }
    public ContentFormats Format { get; set; }
    //public bool IsEmpty { get; set; }
    //public string Summary { get; set; }
}
