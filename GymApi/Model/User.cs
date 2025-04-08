using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApi.Model
{
    public class User: Audit
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? MobileNo { get; set; }
        public string? Address { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string? Role { get; set; }
        public string? Branch { get; set; }
        public string? Password { get; set; }
        public bool? IsDefaultPassword { get; set; }

    }
}
