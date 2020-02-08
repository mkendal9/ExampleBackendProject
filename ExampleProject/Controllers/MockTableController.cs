using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Objects;

namespace ExampleProject.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [EnableCors("AllowAll")]
  public class MockTableController : Controller
  {
    private readonly IMockTable mockTableRepo;

    public MockTableController(IMockTable context)
    {
      mockTableRepo = context;
    }

    [HttpGet]
    [Route("getAllData")]
    public async Task<List<MockTableModel>> getAllData()
    {
      try
      {
        var result = await mockTableRepo.getAllDataFromTable();

        return result;
      }
      catch(Exception e)
      {
        throw e;
      }
    }

    [HttpGet]
    [Route("getSpecificRow/{id}")]
    public async Task<MockTableModel> getOneRecordById(Guid id)
    {
      try
      {
        var result = await mockTableRepo.getRowById(id);

        return result;
      }
      catch(Exception e)
      {
        throw e;
      }
    }
  }
}