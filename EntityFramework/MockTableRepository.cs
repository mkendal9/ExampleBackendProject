using Microsoft.EntityFrameworkCore;
using Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
  public class MockTableRepository : IMockTable
  {
    private readonly DbContextRead db;
    public MockTableRepository(DbContextRead context)
    {
      db = context;
    }

    public async Task<List<MockTableModel>> getAllDataFromTable()
    {
      return await db.MockTable.ToListAsync();
    }

    public async Task<MockTableModel> getRowById(Guid id)
    {
      try
      {
        return await db.MockTable.FindAsync(id);
      }
      catch(Exception e)
      {
        throw e;
      }
    }
  }
}
