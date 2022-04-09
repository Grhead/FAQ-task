using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class TaskX
    {
        public TaskX()
        {
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int? UsersSetId { get; set; }
        public int? UsersGetId { get; set; }
        public int StatusId { get; set; }
        public string? Answer { get; set; }
        public virtual User UsersSet { get; set; }
        public virtual User UsersGet { get; set; }
        public virtual Status Status { get; set; }
    }
}
