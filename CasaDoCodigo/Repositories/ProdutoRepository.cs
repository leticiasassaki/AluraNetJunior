﻿using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {

        private readonly ICategoriaRepository categoriaRepository;
        public ProdutoRepository(ApplicationContext contexto,
            ICategoriaRepository categoriaRepository) : base(contexto)
        {
            this.categoriaRepository = categoriaRepository;
        }

        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }

        public IList<Produto> GetProdutos(string nomeProduto)
        {
            return dbSet.Include(p => p.Categoria)
                .Where(p => p.Nome.Contains(nomeProduto) || p.Categoria.Nome.Contains(nomeProduto))
                .ToList();
        }

        public async Task SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                var categoriaDB = categoriaRepository.GetCategoria(livro.Categoria);

                if (categoriaDB == null)
                {
                    await categoriaRepository.SaveCategoria(livro.Categoria);
                    categoriaDB = categoriaRepository.GetCategoria(livro.Categoria);
                }

                var idCategoria = categoriaDB.Id;

                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco, idCategoria));
                }
            }
            await contexto.SaveChangesAsync();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public decimal Preco { get; set; }
    }
}
