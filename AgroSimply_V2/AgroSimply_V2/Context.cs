using static AgroSimply_V2.Context;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace AgroSimply_V2
{
  
        public class Context : DbContext
        {
            public Context(DbContextOptions<Context> options)
            : base(options)
            {
            }

            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Produtor> Produtores { get; set; }
            public DbSet<Telefone> Telefones { get; set; }
            public DbSet<Propriedade> Propriedades { get; set; }

        }
 }

