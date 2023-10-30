using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class EmprestimoRepositorySqlServer : IEmprestimoRepository
    {
        private readonly SqlContext _context;

        public EmprestimoRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }


        public void DeleteEmprestimo(Emprestimo Emprestimo)
        {
            try
            {
                _context.Set<Emprestimo>().Remove(Emprestimo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Emprestimo GetEmprestimoById(int id)
        {
            return _context.Emprestimo.Find(id);
        }

        public List<Emprestimo> GetEmprestimos()
        {
            return _context.Emprestimo.ToList();
        }

        public Emprestimo InsertEmprestimo(int idAluno, int idLivro , int idBibliotecaria)
        {
            var aluno = _context.Aluno.First(i => i.UserId == idAluno);
            var livro = _context.Livro.First(i => i.LivroId == idLivro);
            var bibliotecaria = _context.Bibliotecaria.First(i => i.UserId == idBibliotecaria);

            var Emprestimo = new Emprestimo
            {
                Aluno = aluno,
                Livro = livro,
                Bibliotecaria = bibliotecaria
            };

            try
            {

                _context.Add(Emprestimo);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return Emprestimo;
        }

        public void UpdateEmprestimo(Emprestimo Emprestimo)
        {
            try
            {
                _context.Entry(Emprestimo).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
