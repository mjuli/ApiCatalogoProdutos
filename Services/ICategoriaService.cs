using ApiCatalogoProdutos.Dto.Input;
using ApiCatalogoProdutos.Model;

namespace ApiCatalogoProdutos.Services
{
    public interface ICategoriaService
    {
        public Task<List<Categoria>> GetAll();
        public Task<Categoria?> GetById(int id);
        public Task<Categoria> Create(CategoriaDto input);
        public Task<Categoria?> Edit(int id, CategoriaDto input);
        public Task Delete(int id);
    }
}