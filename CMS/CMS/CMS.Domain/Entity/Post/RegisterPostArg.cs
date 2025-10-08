using CMS.Domain.Common;
using CMS.Domain.Entity.Categories;

using CMS.Domain.Entity.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.Post;

public class RegisterPostArg:BaseArticle
{
    List<Category> Category = new List<Category>();
    List<Guid> CategoryId = new List<Guid>();


    List<Tag> Tag = new List<Tag>();
    List<Guid> TagId = new List<Guid>();


    //List<RegisterCommentArg> Comment = new List<RegisterCommentArg>();
    List<Guid> CommentId = new List<Guid>();



}
