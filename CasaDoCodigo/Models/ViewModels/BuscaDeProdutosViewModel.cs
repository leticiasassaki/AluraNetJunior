using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaDeProdutosViewModel
    {
        public IList<Categoria> Categorias { get; set; }
        public IList<Produto> Produtos { get; set; }
        public string Pesquisa { get; set; }
    }
}
