using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
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
            throw new NotImplementedException();
        }

        public Emprestimo GetEmprestimoById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Emprestimo> GetEmprestimos()
        {
            throw new NotImplementedException();
        }

        public Emprestimo InsertEmprestimo(int idAluno, int idLivro , int idBibliotecaria)
        {
            var aluno = _context.Aluno.First(i => i.UserId == idAluno);
            var livro = _context.Livro.First(i => i.LivroId == idLivro);
            var bibliotecaria = _context.Bibliotecaria.First(i => i.BibliotecariaId == idBibliotecaria);

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

        public Emprestimo InsertEmprestimo(int idAluno, int idDisciplina)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmprestimo(Emprestimo Emprestimo)
        {
            throw new NotImplementedException();
        }
    }
}
