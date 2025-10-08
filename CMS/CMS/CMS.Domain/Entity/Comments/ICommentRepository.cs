using CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.Comments;

public interface ICommentRepository:IRepository<Comment>
{
    long GetNextId();
    Task Add(Comment comment, CancellationToken token);
    Task Update(CancellationToken token);
    Task<Comment> Get(long id, CancellationToken token);
}
