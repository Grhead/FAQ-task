﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public partial class Status
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual List<TaskX> TaskX { get; set; }
    }
}