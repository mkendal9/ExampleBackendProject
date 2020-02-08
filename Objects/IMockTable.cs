using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
  public interface IMockTable
  {
    Task<List<MockTableModel>> getAllDataFromTable();

    Task<MockTableModel> getRowById(Guid id);
  }
}
