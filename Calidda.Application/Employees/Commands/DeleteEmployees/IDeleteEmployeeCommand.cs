using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Application.Employees.Commands.DeleteEmployees
{
    public interface IDeleteEmployeeCommand
    {
        Task ExecuteAsync(int Id);
    }
}
