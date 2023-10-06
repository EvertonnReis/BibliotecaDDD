using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IBibliotecariaRepository
    {
        public List<Bibliotecaria> GetBibliotecarias();
        public Bibliotecaria GetBibliotecariaById(int id);
        public void InsertBibliotecaria(Bibliotecaria bibliotecaria);
        public void UpdateBibliotecaria(Bibliotecaria bibliotecaria);
        public void DeleteBibliotecaria(Bibliotecaria bibliotecaria);
    }
}
