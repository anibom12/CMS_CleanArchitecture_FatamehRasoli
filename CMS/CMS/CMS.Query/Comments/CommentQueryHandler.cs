
using CMS.Read.Dapper.Common;
using Dapper;
using MediatR;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Query.Comments;

public class CommentQueryHandler:
    IRequestHandler<GetCommentQuery, GetCommentDto>,
    IRequestHandler<GetCommentsQuery, IEnumerable<GetCommentDto>>
{
    private readonly IDapperQuery dapperQuery;

    public CommentQueryHandler(IDapperQuery dapperQuery)
    {
        this.dapperQuery = dapperQuery;
    }

    public async Task<GetCommentDto> Handle(GetCommentQuery query, CancellationToken token)
    {
        const string sql = @"
            SELECT [Id], [Content]
            FROM [dbo].[Comment]
            WHERE [Id] = @Id AND [IsDeleted] = 0";

        using IDbConnection connection = dapperQuery.CreateConnection();

        var result = await connection.QueryFirstOrDefaultAsync<GetCommentDto>(sql, new { query.Id });

        return result;
    }

    public async Task<IEnumerable<GetCommentDto>> Handle(GetCommentsQuery query, CancellationToken token)
    {
        const string sql = @"
            SELECT [Id], [Content]
            FROM [dbo].[Comment]
            WHERE [IsDeleted] = 0";

        using IDbConnection connection = dapperQuery.CreateConnection();

        var result = await connection.QueryAsync<GetCommentDto>(sql);

        return result;
    }
}