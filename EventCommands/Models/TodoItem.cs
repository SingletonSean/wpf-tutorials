using System;
using System.Collections.Generic;
using System.Text;

namespace EventCommands.Models
{
    public class TodoItem
    {
        public string Description { get; set; }
        public string OwnerName { get; set; }
        public bool IsCompleted { get; set; }
    }
}
