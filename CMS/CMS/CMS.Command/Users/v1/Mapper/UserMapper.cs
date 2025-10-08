using CMS.Domain.Entity.User.args;
using CMS.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Command.Users.v1.Mapper;

public abstract class UserMapper
{
    public static RegisterUserArg Map(RegisterUserCommand userCommand)
    {
        return new RegisterUserArg
        {
            Id = userCommand.Id,
            FirstName = userCommand.FirstName,
            LastName = userCommand.LastName,
            Email = userCommand.Email,
            Phone = userCommand.Phone,
            Role = userCommand.Role

        };
    }
    public static ModifyUserArg Map(ModifyUserCommand userCommand)
    {
        return new ModifyUserArg
        {
            Id = userCommand.Id,
            FirstName = userCommand.FirstName,
            LastName = userCommand.LastName,
            Email = userCommand.Email,
            Phone = userCommand.Phone,
            Role = userCommand.Role

        };
    }

}
