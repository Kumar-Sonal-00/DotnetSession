using EmployeeServiceAPI.Models;
using EmployeeServiceAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeServiceAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmpDataAccessLayer dal;
        public EmployeesController(IEmpDataAccessLayer dal)
        {
            this.dal= dal;
        }

        [HttpGet]
        [Route("GetMsg")]
        //[Authorize(Roles ="admin")]
        public IActionResult GetMsg()
        {
            return Ok("Hello moto");
        }

        [HttpGet]
        [Route("GetEmps")]
        //[Authorize(Roles ="admin")]
        public IActionResult GetEmps()
        {
            return Ok(dal.GetEmps());
        }

        [HttpGet]
        [Route("GetEmpById/{id}")]
        //[Authorize(Roles ="guest")]
        public IActionResult GetEmpById(int id)
        {
            return Ok(dal.GetEmployeeById(id));
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult Post([FromBody] Employee emp)
        {
            dal.AddEmployee(emp);
            return Ok("Record inserted");
        }
    }
}
