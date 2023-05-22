using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Agrosimply_V1._0.Models
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
