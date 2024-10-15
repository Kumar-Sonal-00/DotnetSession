using DepartmentServiceAPI.Models;
using DepartmentServiceAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentDataAccessLayer dal;
        public DepartmentsController(IDepartmentDataAccessLayer dal)
        {
            this.dal = dal;
        }

        [HttpGet]
        [Route("GetDepts")]
        public IActionResult GetDepts()
        {
            return Ok(dal.GetDepts());
        }

        [HttpPost]
        [Route("AddDepartment")]
        public IActionResult AddDepartment(Department dept)
        {
            dal.AddDepartment(dept);
            return Ok("Department record added");
        }
    }
}
