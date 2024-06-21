using ApiCatalogoProdutos.Dto.Input;
using ApiCatalogoProdutos.Model;

namespace ApiCatalogoProdutos.Services
{
    public interface IProdutoService
    {
        public Task<List<Produto>> GetAll();
        public Task<Produto?> GetById(int id);
        public Task<Produto> Create(ProdutoDto input);
        public Task<Produto?> Edit(int id, ProdutoDto input);
        public Task Delete(int id);
    }
}