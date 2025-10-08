using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Query.Users.v1;

public record class GetUserQuery(long Id):IRequest<GetUserDto>;
