using System;
using System.Collections.Generic;

namespace DapperASPNetCore.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Position { get; set; } = null!;
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
    }
}
