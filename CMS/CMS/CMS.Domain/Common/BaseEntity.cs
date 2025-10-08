using System.ComponentModel.DataAnnotations;

namespace CMS.Domain.Common;

public abstract class BaseEntity
{
    [Key]
    public long Id { get; set; }
    public bool IsDeleted { get; protected set; } = false;
}
