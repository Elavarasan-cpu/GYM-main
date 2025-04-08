using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApi.Model
{
    public class UserPlan:Audit
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Foreign Key
        public string? Plan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Navigation Property
        public User? User { get; set; }
    }
}
