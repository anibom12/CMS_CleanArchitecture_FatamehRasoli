using CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CMS.Domain.Entity.User;

public interface IUserRepository: IRepository<User>
{
    long GetNextId();
    Task Add(User user, CancellationToken token);
    Task Update(CancellationToken token);
    Task<User> Get(long id, CancellationToken token);
}
