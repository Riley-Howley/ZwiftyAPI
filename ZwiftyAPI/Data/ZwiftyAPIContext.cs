using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZwiftyAPI.Models;

namespace ZwiftyAPI.Data
{
    public class ZwiftyAPIContext : DbContext
    {
        public ZwiftyAPIContext (DbContextOptions<ZwiftyAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ZwiftyAPI.Models.Product> Product { get; set; } = default!;

        public DbSet<ZwiftyAPI.Models.Inventory>? Inventory { get; set; }

        public DbSet<ZwiftyAPI.Models.Supplier>? Supplier { get; set; }

        public DbSet<ZwiftyAPI.Models.OutGoingShipment>? OutGoingShipment { get; set; }

        public DbSet<ZwiftyAPI.Models.IncomingShipment>? IncomingShipment { get; set; }
    }
}
