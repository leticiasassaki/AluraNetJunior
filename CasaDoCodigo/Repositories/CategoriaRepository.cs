using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }
        public IList<Categoria> GetCategorias()
        {
            return dbSet.ToList();
        }

        public Categoria GetCategoria(string nomeCategoria)
        {
            return dbSet
                .Where(ip => ip.Nome == nomeCategoria)
                .SingleOrDefault();
        }

        public async Task SaveCategoria(string nomeCategoria)
        {
            if (!dbSet.Where(p => p.Nome == nomeCategoria).Any())
            {
                dbSet.Add(new Categoria(nomeCategoria));

                await contexto.SaveChangesAsync();
            }
        }
    }
}
