using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBackend.Domain.Entities;

namespace TesteBackend.Infra.Config
{
    public class TarefasConfig : IEntityTypeConfiguration<TarefaEntities>
    {
        public void Configure(EntityTypeBuilder<TarefaEntities> builder)
        {
            builder.Property(p => p.Id)                  
                   .IsRequired();

            builder.Property(p => p.Titulo)
                   .HasMaxLength(200);

            builder.Property(p => p.Concluida)
                   .IsRequired();

        }
    }
}
