using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CbWebApp.Models;
using CbWebApp.Domains;

namespace CbWebApp.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Fluent API. Colocar a proprieda Nome do Domain Tarefa como Required.
            builder.Entity<Tarefa>()
                          .Property(x => x.Nome)
                          .IsRequired();

            //criar foreign key UsuarioId para o usuario que criou a tarefa na Tabela Tarefa coluna nova UserId.
            builder.Entity<Tarefa>()
                          .HasOne(c => c.User)
                          .WithMany(x => x.Tarefas)
                          .HasForeignKey(f => f.UserId)
                          .HasConstraintName("UserId")
                          .OnDelete(DeleteBehavior.Cascade)
                          .IsRequired();
        }
    }
}
