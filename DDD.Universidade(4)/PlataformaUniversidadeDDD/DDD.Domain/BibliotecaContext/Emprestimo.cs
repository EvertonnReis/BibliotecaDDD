using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.SecretariaContext
{
    public class Emprestimo
    {
        public int EmprestimoId { get; set; }
        
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
        public int BibliotecariaId { get; set; }
        public Bibliotecaria Bibliotecaria { get; set; }

        public DateTime Data { get; set; }
        //public ICollection<Aluno> Alunos { get; set; }

    }
}
