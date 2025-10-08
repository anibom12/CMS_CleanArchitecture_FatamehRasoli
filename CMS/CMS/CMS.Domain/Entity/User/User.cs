using CMS.Domain.Common;
using CMS.Domain.Entity.User.args;
using CMS.Domain.Enum;
using CMS.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;


namespace CMS.Domain.Entity.User;

public class User:BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public UserRoles Role { get; set; } 

    private User() { }
    private User(RegisterUserArg arg)
    {
        Id = arg.Id;
        FirstName = arg.FirstName;
        LastName = arg.LastName;
        Email = arg.Email;
        Phone = arg.Phone;
        Role =arg.Role;
        
    }
    public static async Task<User> New(RegisterUserArg arg, IUserService service, CancellationToken token)
    {
        
        return new User(arg);
    }
    public async Task Modify(ModifyUserArg arg, IUserService service, CancellationToken token)
    {

       
        FirstName = arg.FirstName??FirstName;
        LastName = arg.LastName??LastName;
        Email = arg.Email??Email;
        Phone = arg.Phone ?? Phone;
        Role = arg.Role;
    }
    public void Remove()
    {
        
        IsDeleted = true;
       
    }
   
}