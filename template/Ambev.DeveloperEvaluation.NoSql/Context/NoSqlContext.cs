using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Ambev.DeveloperEvaluation.NoSql.Context
{
    public class NoSqlContext : DbContext
    {

        public DbSet<Notification> Notifications { get; init; }

        public static NoSqlContext Create(IMongoDatabase database) =>
            new(new DbContextOptionsBuilder<NoSqlContext>()
        .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
        .Options);

        public NoSqlContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Notification>().ToCollection("Notifications");
            modelBuilder.Entity<Notification>().HasKey(n => n.Id);
        }

    }
}
