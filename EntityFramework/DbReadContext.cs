using Microsoft.EntityFrameworkCore;
using System;
using Objects;

namespace EntityFramework
{
  public class DbContextRead : DbContext
  {
    public DbContextRead(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<MockTableModel> MockTable { get; set; }
  }
}
