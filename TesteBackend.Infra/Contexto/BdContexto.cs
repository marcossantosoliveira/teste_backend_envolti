using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TesteBackend.Infra.Contexto
{
    
    public class BdContexto : DbContext
    {



        public BdContexto(DbContextOptions<BdContexto> opcoes) : base(opcoes)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=tarefa;Integrated Security=True;" +
                                             "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;" +
                                               "Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        public DbSet<Clientes> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ClienteConfiguracao());
        }
    }
}
