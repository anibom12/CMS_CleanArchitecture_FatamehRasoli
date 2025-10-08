using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CMS.Domain.Enum;
using MediatR;
namespace CMS.Command.Users.v1;

public class ModifyUserCommand: IRequest<long>
{
   [JsonIgnore] public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public UserRoles Role { get; set; }
}
