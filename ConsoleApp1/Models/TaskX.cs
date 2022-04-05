using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class TaskX
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public int UserGet { get; set; }
        public int UserSet { get; set; }
        public string Status { get; set; }
        public string Answer { get; set; }

        //public User User { get; set; }
    }
}
