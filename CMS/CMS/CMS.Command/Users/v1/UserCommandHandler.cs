
using CMS.Command.Users.v1.Mapper;
using CMS.Domain.Entity.User;
using CMS.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CMS.Command.Users.v1;

public class UserCommandHandler:
    IRequestHandler<ModifyUserCommand,long>,
    IRequestHandler<RegisterUserCommand, long>,
    IRequestHandler<RemoveUserCommand, long>
{
    private readonly IUserRepository repository;
    public UserCommandHandler(IUserRepository repository)
    {
        this.repository = repository;
    }
    public async Task<long> Handle(RegisterUserCommand command, CancellationToken token)
    {
        command.Id = repository.GetNextId();
        var arg = UserMapper.Map(command);
        var user = await User.New(arg, null, token);
        await repository.Add(user, token);
        return command.Id;
    }
    public async Task<long> Handle(ModifyUserCommand command, CancellationToken token)
    {
        var user = await repository.Get(command.Id, token);
        var arg = UserMapper.Map(command);
        user.Modify(arg, null, token);
        await repository.Update(token);
        return user.Id;
    }

    public async Task<long> Handle(RemoveUserCommand command, CancellationToken token)
    {
        var user = await repository.Get(command.Id, token);
        user.Remove();
        await repository.Update(token);
        return user.Id;
    }


};
