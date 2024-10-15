using EFCoreDatabaseFirstApproach.BusinessLayer;
using EFCoreDatabaseFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreDatabaseFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmpBusinessLayer _businessLayer;
        public EmployeesController(IEmpBusinessLayer businessLayer)
        {
            this._businessLayer = businessLayer;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<TblEmployee> Get()
        {
            return _businessLayer.GetEmps();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ApiResponse<TblEmployee> response = new ApiResponse<TblEmployee>();
            try
            {
                var record =_businessLayer.GetEmployee(id);
                response.Data = record;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return Ok(response);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] TblEmployee emp)
        {
            _businessLayer.AddEmployee(emp);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TblEmployee emp)
        {
            _businessLayer.UpdateEmployee(emp);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var record = _businessLayer.GetEmployee(id);
                _businessLayer.DeleteEmployee(id);
                return Ok("Record deleted for id:" + id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpGet]
        [Route("DivideNumbers/{a}/{b}")]
        public IActionResult DivideNumbers(int a,int b)
        {
            ApiResponse<int> apiResponse = new ApiResponse<int>();

            try
            {
                int result = a / b;
                apiResponse.Data = result;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.ErrorMessage = "Error occurred:" + ex.Message;
            }

            return Ok(apiResponse);
        }
    }
}
