using DDD.Domain.SecretariaContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DDD.Infra.MemoryDb
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BibliotecaDb");
        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Bibliotecaria> Bibliotecarias { get; set; }

    }
}
