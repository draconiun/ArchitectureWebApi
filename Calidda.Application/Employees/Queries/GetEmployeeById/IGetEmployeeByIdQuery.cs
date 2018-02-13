using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Application.Employees.Queries.GetEmployeeById
{
    public interface IGetEmployeeByIdQuery
    {
        Task<GetEmployeeByIdModel> ExecuteAsync(int Id);
    }
}
