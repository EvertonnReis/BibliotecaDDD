using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface ILivroRepository
    {
        public List<Livro> GetLivros();
        public Livro GetLivroById(int id);
        public void InsertLivro(Livro livro);
        public void UpdateLivro(Livro livro);
        public void DeleteLivro(Livro livro);
    }
}
