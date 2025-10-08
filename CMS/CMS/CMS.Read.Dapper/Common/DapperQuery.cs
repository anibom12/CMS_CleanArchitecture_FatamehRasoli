
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Read.Dapper.Common;

public class DapperQuery:IDapperQuery
{
    private readonly IConfiguration configuration;
    private readonly string connectionString;
    public DapperQuery( string connectionString)
    {
        
        this.connectionString = connectionString;
    }
    public IDbConnection CreateConnection()
    {
        return new SqlConnection(connectionString);
    }

}
