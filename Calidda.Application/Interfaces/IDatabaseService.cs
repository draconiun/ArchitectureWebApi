using Calidda.Domain.Common;
using Calidda.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Application.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<Employee> Employees { get; set; }
        void Save();
        Task<int> SaveAsync();
        void Update(IEntity entity);
    }
}
