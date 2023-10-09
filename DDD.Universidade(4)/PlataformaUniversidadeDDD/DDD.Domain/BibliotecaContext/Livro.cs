using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.SecretariaContext
{
    public class Livro
    {
        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public bool Emprestado { get; set; }
        //public IList<Matricula>? Matriculas { get; set; }
        //public IList<Aluno>? Alunos { get; set; }

    }
}
