using Calidda.Application.Employees.Commands.CreateEmployees;
using Calidda.Application.Employees.Commands.DeleteEmployees;
using Calidda.Application.Employees.Commands.UpdateEmployees;
using Calidda.Application.Employees.Queries.ExistEmployee;
using Calidda.Application.Employees.Queries.GetEmployeeById;
using Calidda.Application.Employees.Queries.GetEmployees;
using Calidda.Common.Messages;
using Calidda.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Calidda.Service.Controllers
{
    [RoutePrefix("api/Employees")]
    public class EmployeesController : ApiController
    {
        #region Service Declarations
        readonly IGetEmployeesQuery _getEmployeesQuery;
        readonly ICreateEmployeeCommand _createEmployeeCommand;
        readonly IUpdateEmployeeCommand _updateEmployeeCommand;
        readonly IDeleteEmployeeCommand _deleteEmployeeCommand;
        readonly IGetEmployeeByIdQuery _getEmployeeByIdQuery;
        readonly IExistEmployeeQuery _existEmployeeQuery;
        #endregion

        #region Constructor
        public EmployeesController(IGetEmployeesQuery getEmployeesQuery,
                                    ICreateEmployeeCommand createEmployeeCommand,
                                    IUpdateEmployeeCommand updateEmployeeCommand,
                                    IDeleteEmployeeCommand deleteEmployeeCommand,
                                    IGetEmployeeByIdQuery getEmployeeByIdQuery,
                                    IExistEmployeeQuery existEmployeeQuery)
        {
            _getEmployeesQuery = getEmployeesQuery;
            _createEmployeeCommand = createEmployeeCommand;
            _updateEmployeeCommand = updateEmployeeCommand;
            _deleteEmployeeCommand = deleteEmployeeCommand;
            _getEmployeeByIdQuery = getEmployeeByIdQuery;
            _existEmployeeQuery = existEmployeeQuery;
        }
        #endregion

        #region Request
        [HttpGet]
        [Route("{Id}/GetEmployeeByIdAsync", Name = "GetEmployeeByIdAsync")]
        public async Task<IHttpActionResult> GetEmployeeByIdAsync(int Id)
        {
            if(!(await _existEmployeeQuery.ExecuteAsync(Id)))
                return Content(HttpStatusCode.NotFound, EmployeeMessages.EmployeeDoesNotExistMessage);

            var model = await _getEmployeeByIdQuery.ExecuteAsync(Id);

            return Ok(model);
        }

        [HttpGet]
        [Route("GetEmployeesAsync")]
        public async Task<IHttpActionResult> GetEmployeesAsync()
        {
            var model = await _getEmployeesQuery.ExecuteAsync();
            return Ok(model);
        }

        [HttpPost]
        [Route("CreateEmployeeAsync")]
        public async Task<IHttpActionResult> CreateEmployeeAsync([FromBody] CreateEmployeeModel model)
        {
            if (model == null)
                return BadRequest();

            var employee = await _createEmployeeCommand.ExecuteAsync(model);

            var returnEmployee = MapEmployee(employee);

            return CreatedAtRoute("GetEmployeeByIdAsync", new { Id = employee.Id }, returnEmployee);
        }

        [HttpPut]
        [Route("{Id}/UpdateEmployeeAsync")]
        public async Task<IHttpActionResult> UpdateEmployeeAsync(int Id,[FromBody] UpdateEmployeeModel model)
        {
            if (model == null)
                return BadRequest();

            if (!(await _existEmployeeQuery.ExecuteAsync(Id)))
                return Content(HttpStatusCode.NotFound, EmployeeMessages.EmployeeDoesNotExistMessage);

            var employee = await _updateEmployeeCommand.ExecuteAsync(Id,model);

            var returnEmployee = MapEmployee(employee);

            return CreatedAtRoute("GetEmployeeByIdAsync", new { Id = employee.Id }, returnEmployee);
        }

        [HttpDelete]
        [Route("{Id}/DeleteEmployeeAsync")]
        public async Task<IHttpActionResult> DeleteEmployeeAsync(int Id)
        {
            if (!(await _existEmployeeQuery.ExecuteAsync(Id)))
                return Content(HttpStatusCode.NotFound, EmployeeMessages.EmployeeDoesNotExistMessage);

            await _deleteEmployeeCommand.ExecuteAsync(Id);

            return StatusCode(HttpStatusCode.NoContent);
        }
        #endregion

        #region Methods
        private GetEmployeeByIdModel MapEmployee(Employee model)
        {
            var returnModel = new GetEmployeeByIdModel();
            returnModel.Id = model.Id;
            returnModel.Name = model.Name;
            returnModel.FirstName = model.FirstName;
            returnModel.Age = model.Age;

            return returnModel;
        }
        #endregion
    }
}
