using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CMS.Presistence.EF.Hilo;

public class HiloIdGenerator:IHiloIdGenerator
{
    private readonly CMSDbContext _context;

    public HiloIdGenerator(CMSDbContext context)
    {
        _context = context;
    }

    public long GetNextId<T>()
    {
        var sequenceName = $"SQ_Hilo_{typeof(T).Name}";
        var sql = $"SELECT NEXT VALUE FOR {sequenceName}";

        var connection = _context.Database.GetDbConnection();

        using var command = connection.CreateCommand();
        command.CommandText = sql;

        if (connection.State != System.Data.ConnectionState.Open)
            connection.Open();

        var result = command.ExecuteScalar();

        return Convert.ToInt64(result);

    }
}
