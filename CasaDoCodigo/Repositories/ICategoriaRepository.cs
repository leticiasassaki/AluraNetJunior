using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Task SaveCategoria(string nomeCategoria);
        Categoria GetCategoria(string nomeCategoria);
        IList<Categoria> GetCategorias();
    }
}
