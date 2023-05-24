using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgroSimply_V2;

namespace AgroSimply_V2.Data
{
    public class AgroSimply_V2Context : DbContext
    {
        public AgroSimply_V2Context (DbContextOptions<AgroSimply_V2Context> options)
            : base(options)
        {
        }

        public DbSet<AgroSimply_V2.Produtor> Produtor { get; set; } = default!;
    }
}
