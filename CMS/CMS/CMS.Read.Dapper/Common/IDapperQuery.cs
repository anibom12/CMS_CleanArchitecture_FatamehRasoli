using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Read.Dapper.Common;

public interface IDapperQuery
{
    IDbConnection CreateConnection();
}
