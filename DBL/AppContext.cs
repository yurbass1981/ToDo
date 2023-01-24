using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.Entities;

namespace ToDo.DBL
{
    public class AppContext : DbContext
    {
        
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}