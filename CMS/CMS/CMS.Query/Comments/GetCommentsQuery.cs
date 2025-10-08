using CMS.Query.Users.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Query.Comments;

public  record GetCommentsQuery : IRequest<IEnumerable<GetCommentDto>>;

