using System;
using System.Collections.Generic;

namespace DapperASPNetCore.Models
{
    public partial class Company
    {
        public Company()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Country { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
