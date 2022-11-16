using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SalesManagement2021
{
    class SalesManagementDbContext : DbContext
    {
        public DbSet<M_Authority> M_Authoritys { get; set; }
        public DbSet<M_Category> M_Categorys { get; set; }
        public DbSet<M_Division> M_Divisions { get; set; }
        public DbSet<M_Item> M_Items { get; set; }
        public DbSet<M_Maker> M_Makers { get; set; }
        public DbSet<M_Position> M_Positions { get; set; }

        public DbSet<M_Staff> M_Staffs { get; set; }
        public DbSet<M_Store> M_Stores { get; set; }
        public DbSet<M_Tax> M_Taxs { get; set; }
        public DbSet<M_Message> M_Messages { get; set; }

    }
}
