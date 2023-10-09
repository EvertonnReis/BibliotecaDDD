using DDD.Domain.SecretariaContext;
using DDD.Domain.UserManagementContext;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.SQLServer
{
    public class SqlContext : DbContext
    {

        //https://balta.io/blog/ef-crud
        //https://jasonwatmore.com/post/2022/03/18/net-6-connect-to-sql-server-with-entity-framework-core

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BibliotecaDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Emprestimo>()
                        .HasOne(e => e.Aluno)
                        .WithMany()
                        .HasForeignKey(e => e.AlunoId)
                        .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().UseTpcMappingStrategy();
            modelBuilder.Entity<Aluno>().ToTable("Alunos");
            modelBuilder.Entity<Livro>().ToTable("Livros");
            modelBuilder.Entity<Bibliotecaria>().ToTable("Bibliotecarias");
            //https://learn.microsoft.com/pt-br/ef/core/modeling/inheritance
        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Bibliotecaria> Bibliotecaria { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }
        public DbSet<User> User { get; set; }
    }
}
