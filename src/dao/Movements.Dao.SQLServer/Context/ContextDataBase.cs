using Microsoft.EntityFrameworkCore;
using Movements.Domain;
using System;

namespace Movements.Dao.SQLServer
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<Movement> Movement { get; set; }

        public DbContext Instance => this;
    }
}
