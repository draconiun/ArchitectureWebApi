using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Application.Employees.Queries.ExistEmployee
{
    public interface IExistEmployeeQuery
    {
        Task<Boolean> ExecuteAsync(int Id);
    }
}
