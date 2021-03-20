using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamZ.Shared;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<StoreItem> StoreItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StoreTransaction> Transactions { get; set; }
        public DbSet<StoreUser> Users { get; set; }
        public DbSet<LogMessage> LogMessages { get; set; }
    }
}
