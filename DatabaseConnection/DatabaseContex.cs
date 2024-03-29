

using backend_101.Constants;
using backend_101.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_101.DatabaseConnection
{
public class DatabaseContex : DbContext
{
    public DatabaseContex(DbContextOptions<DatabaseContex> options) : base(options)
    {

    }
    public DbSet<TransactionModel> entityTransaction { set; get; }
    public DbSet<HitHistoryModel> entityHitHistory { set; get; }
    public DbSet<ResultHistoryModel> entityResultHistory { set; get; }
    public DbSet<RequestHistoryModel> entityRequestHistory { set; get; }
    public DbSet<ResponseHistoryModel> entityResponseHistory { set; get; }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable(StringConstant.STRING_TABLE_USER);
            modelBuilder.Entity<HitHistoryModel>().ToTable(StringConstant.STRING_TABLE_HITHISTORY);
            modelBuilder.Entity<ResultHistoryModel>().ToTable(StringConstant.STRING_TABLE_RESULTHISTORY);
            modelBuilder.Entity<RequestHistoryModel>().ToTable(StringConstant.STRING_TABLE_REQUESTHISTORY);
            modelBuilder.Entity<ResponseHistoryModel>().ToTable(StringConstant.STRING_TABLE_RESPONSEHISTORY);
        }
}
}

