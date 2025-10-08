
using MediatR;
using Dapper;
using CMS.Read.Dapper.Common;
namespace CMS.Query.Users.v1;

public class UserQueryHandler:
    IRequestHandler<GetUserQuery,GetUserDto>,
    IRequestHandler<GetUsersQuery,IEnumerable<GetUserDto>>
{
    private IDapperQuery dapperQuery;
    public UserQueryHandler(IDapperQuery dapperQuery)
    {
        this.dapperQuery = dapperQuery;
    }
    public async Task<GetUserDto> Handle(GetUserQuery query, CancellationToken token)
    {
        const string sql = "SELECT [Id]" +
                           "   ,[FirstName]" +
                           "   ,[LastName]" +
                           "   ,[Email]" +
                           "   ,[Phone]" +
                           "   ,[Role]" +
                           "FROM [dbo].[Users]" +
                           "Where [Id]=@Id AND [IsDeleted] = 0";

        GetUserDto result;

        using (var connection = dapperQuery.CreateConnection())
        {
            result = await connection.QueryFirstOrDefaultAsync<GetUserDto>(sql, new { query.Id });
        }


        return result;
    }

    public async Task<IEnumerable<GetUserDto>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
    {
        const string sql = "SELECT [Id]" +
                           "   ,[FirstName]" +
                           "   ,[LastName]" +
                           "   ,[Email]" +
                           "   ,[Phone]" +
                           "   ,[Role]" +
                           "FROM [dbo].[Users]" +
                           "Where [Id]=@Id AND [IsDeleted] = 0";

        IEnumerable<GetUserDto>? result;

        using (var connection = dapperQuery.CreateConnection())
        {
            result = await connection.QueryAsync<GetUserDto>(sql, query);
        }

        return result;
    }

}
