using Microsoft.EntityFrameworkCore;
using CMS.Domain.Entity.Comments;
using CMS.Presistence.EF.Hilo;


namespace CMS.Presistence.EF.Repositories.Comments;

public class CommentRepository: ICommentRepository
{
    private readonly CMSDbContext dbContext;
    private readonly IHiloIdGenerator hiloGenerator;
    public CommentRepository(CMSDbContext dbContext, IHiloIdGenerator hiloGenerator)
    {
        this.dbContext = dbContext;
        this.hiloGenerator = hiloGenerator;
    }

    public long GetNextId()
    {
        return hiloGenerator.GetNextId<Comment>();
    }

    public async Task Add(Comment comment,CancellationToken token)
    {
        await dbContext.AddAsync(comment, token);
        await dbContext.SaveChangesAsync(token);
    }

    public async Task Update(CancellationToken token)
    {
        await dbContext.SaveChangesAsync(token);
    }

    public async Task<Comment> Get(long id ,CancellationToken token)
    {
        return await dbContext.Comments.SingleAsync(x => x.Id == id,token);
    }
    
}
