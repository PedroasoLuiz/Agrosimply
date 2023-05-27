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
        public AgroSimply_V2Context(DbContextOptions<AgroSimply_V2Context> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produtor>().HasData(GetSeedDataProdutor());
            modelBuilder.Entity<Propriedade>().HasData(GetSeedDataPropriedade());
        }
        public DbSet<AgroSimply_V2.Produtor> Produtor { get; set; } = default!;

        public DbSet<AgroSimply_V2.Propriedade> Propriedade { get; set; } = default!;

        public DbSet<AgroSimply_V2.Telefone> Telefone { get; set; } = default!;

        public DbSet<AgroSimply_V2.Usuario> Usuario { get; set; } = default!;


        private Propriedade[] GetSeedDataPropriedade() => new Propriedade[]
        {
            new Propriedade
            {
                IdPropriedade = 1,
                Nome = "Jardim do Eden",
                Cidade = "Mundo",
                Cultura = "Arvore da Vida",
                Localização = "Paraiso",
                Extensão = 10000000000000000000
             }
        };

        private Produtor[] GetSeedDataProdutor() => new Produtor[]
        {
           new Produtor
           {
               IdProdutor = 1,
               Nome = "Jesus",
               Email ="Jesus@ceu.wo",
               CPF = 00000000000,
               CNPJ = 000000000000000,
               Atividade = "Criador"
           }
        };

        

    }
}

