using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.SecretariaContext
{
    public class Bibliotecaria: User
    {
        public int BibliotecariaId { get; set; }
        public List<Emprestimo> Emprestimo { get; set; }
    }
}
