using CMS.Command.Users.v1.Mapper;
using CMS.Command.Users.v1;
using CMS.Domain.Entity.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Domain.Entity.Comments;
using CMS.Command.Comments.v1.Mapper;

namespace CMS.Command.Comments.v1;

public class CommentCommandHandler:
    IRequestHandler<RegisterCommentCommand,long>,
    IRequestHandler< ModifyCommentCommand,long>,
    IRequestHandler<RemoveCommentCommand,long>
{
    private readonly ICommentRepository repository;
    public CommentCommandHandler(ICommentRepository repository)
    {
        this.repository = repository;
    }
    public async Task<long> Handle(RegisterCommentCommand command, CancellationToken token)
    {
        command.Id = repository.GetNextId();
        var arg = CommentMapper.Map(command);
        var comment = await Comment.New(arg, null, token);
        await repository.Add(comment, token);
        return command.Id;
    }
    public async Task<long> Handle(ModifyCommentCommand command, CancellationToken token)
    {
        var comment = await repository.Get(command.Id, token);
        var arg = CommentMapper.Map(command);
        comment.Modify(arg, null,token);
        await repository.Update(token);
        return comment.Id;
    }

    public async Task<long> Handle(RemoveCommentCommand command, CancellationToken token)
    {
        var comment = await repository.Get(command.Id, token);
        comment.Remove();
        await repository.Update(token);
        return comment.Id;
    }
}
