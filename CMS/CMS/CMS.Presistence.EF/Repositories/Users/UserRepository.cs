
using Microsoft.EntityFrameworkCore;
using CMS.Domain.Entity.User;
using CMS.Presistence.EF.Hilo;
namespace CMS.Presistence.EF.Repositories.Users;

public class UserRepository: IUserRepository
{
    private readonly CMSDbContext dbcontext;
    private readonly IHiloIdGenerator hiloIdGenerator;

    public UserRepository(CMSDbContext dbcontext, IHiloIdGenerator hiloIdGenerator)
    {
        this.dbcontext = dbcontext;
        this.hiloIdGenerator = hiloIdGenerator;
    }
    public long GetNextId()
    {
        return hiloIdGenerator.GetNextId<User>();
    }
    public async Task Add(User user, CancellationToken token)
    {
        await dbcontext.AddAsync(user, token);
        await dbcontext.SaveChangesAsync(token);
    }
    public async Task<User> Get(long id, CancellationToken token)
    {
        return await dbcontext.Users.SingleAsync(x => x.Id == id);
    }
    public async Task Update(CancellationToken token)
    {
        await dbcontext.SaveChangesAsync(token);
    }
}
