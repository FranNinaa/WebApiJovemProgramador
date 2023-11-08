using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationAlunos.Models;

namespace WebApplicationAlunos.Data.Map
{
    public class AlunoMap : IEntityTypeConfiguration<AlunoModel>
    {
        public void Configure(EntityTypeBuilder<AlunoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x =>x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x =>x.DataNascimento).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Curso).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
