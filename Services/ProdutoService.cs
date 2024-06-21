using ApiCatalogoProdutos.Context;
using ApiCatalogoProdutos.Dto.Input;
using ApiCatalogoProdutos.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoProdutos.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> Create(ProdutoDto input)
        {
            Categoria? categoria = await _context.Categorias
                .SingleOrDefaultAsync(c => c.CategoriaId == input.CategoriaId);
            ArgumentNullException.ThrowIfNull(categoria, nameof(categoria));

            Produto produto = new Produto(input.Nome, input.Descricao, input.Preco, input.ImageUrl, input.CategoriaId);
            if (input.Estoque != null)
                produto.Estoque = (float)input.Estoque;

            await _context.AddAsync(produto);
            categoria.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task Delete(int id)
        {
            Produto? produto = await GetById(id);
            ArgumentNullException.ThrowIfNull(produto);

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto?> Edit(int id, ProdutoDto input)
        {
            Produto? produto = await GetById(id);
            ArgumentNullException.ThrowIfNull(produto, nameof(produto));

            Categoria? categoria = await _context.Categorias
                .SingleOrDefaultAsync(c => c.CategoriaId == input.CategoriaId);
            ArgumentNullException.ThrowIfNull(categoria, nameof(categoria));

            produto.Nome = input.Nome;
            produto.Descricao = input.Descricao;
            produto.Preco = input.Preco;
            produto.ImageUrl = input.ImageUrl;
            produto.CategoriaId = input.CategoriaId;

            categoria.Produtos.Add(produto);

            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<List<Produto>> GetAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto?> GetById(int id)
        {
            return await _context.Produtos
                .SingleOrDefaultAsync(p => p.ProdutoId == id);
        }
    }
}