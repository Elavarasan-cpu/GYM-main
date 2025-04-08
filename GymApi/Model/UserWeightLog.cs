using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApi.Model
{
    public class UserWeightLog : Audit
    {
        public int Id { get; set; }
        public int UserId { get; set; }  // Foreign Key
        public double InWeight { get; set; }
        public double OutWeight { get; set; }
        public DateTime Date { get; set; }

        // Navigation Property
        public User? User { get; set; }
    }
}
