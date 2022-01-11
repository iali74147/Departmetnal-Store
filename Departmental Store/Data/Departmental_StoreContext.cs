using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Departmental_Store.ViewModels;

namespace Departmental_Store.Data
{
    public class Departmental_StoreContext : DbContext
    {
        public Departmental_StoreContext (DbContextOptions<Departmental_StoreContext> options)
            : base(options)
        {
        }

        public DbSet<Departmental_Store.ViewModels.OrderModel> OrderModel { get; set; }
    }
}
