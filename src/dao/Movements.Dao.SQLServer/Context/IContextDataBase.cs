using Microsoft.EntityFrameworkCore;
using Movements.Domain;

namespace Movements.Dao.SQLServer
{
    public interface IContextDatabase
    {
        DbSet<Movement> Movement { get; set; }

        int SaveChanges();
    }
}
