using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IEmprestimoRepository
    {
        public List<Emprestimo> GetEmprestimos();
        public Emprestimo GetEmprestimoById(int id);
        //public void InsertEmprestimo(Emprestimo Emprestimo);
        public Emprestimo InsertEmprestimo(int idAluno, int idLivro, int idBibliotecaria);
        public void UpdateEmprestimo(Emprestimo Emprestimo);
        public void DeleteEmprestimo(Emprestimo Emprestimo);
    }
}
