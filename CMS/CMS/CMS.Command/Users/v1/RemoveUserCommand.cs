using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Command.Users.v1;

public record class RemoveUserCommand:IRequest<long>
{
    public long Id { get; set; }
}
