using Calidda.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calidda.Persistance.Employees
{
    public class EmployeeConfiguration
           : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Age)
                .IsOptional();
        }
    }
}
