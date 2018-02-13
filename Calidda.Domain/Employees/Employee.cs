using Calidda.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Domain.Employees
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
    }
}
