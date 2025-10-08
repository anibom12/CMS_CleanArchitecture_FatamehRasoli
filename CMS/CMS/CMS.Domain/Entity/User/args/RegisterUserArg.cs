using CMS.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.User.args;

public class RegisterUserArg
{
    public long Id { get;  set; }
    public string FirstName { get;  set; }
    public string LastName { get;  set; }
    public string Email { get;  set; }
    public string Phone { get;  set; }
    public UserRoles Role { get;  set; }
}
