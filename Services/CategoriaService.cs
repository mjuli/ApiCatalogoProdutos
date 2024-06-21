using ApiCatalogoProdutos.Context;
using ApiCatalogoProdutos.Dto.Input;
using ApiCatalogoProdutos.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoProdutos.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly AppDbContext _context;
        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria> Create(CategoriaDto input)
        {
            Categoria categoria = new(input.Nome, input.ImageUrl);
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task Delete(int id)
        {
            Categoria? categoria = await GetById(id);

            ArgumentNullException.ThrowIfNull(categoria);

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<Categoria?> Edit(int id, CategoriaDto input)
        {
            ArgumentNullException.ThrowIfNull(input);

            Categoria? categoria = await GetById(id);
            ArgumentNullException.ThrowIfNull(categoria);

            categoria.Nome = input.Nome;
            categoria.ImageUrl = input.ImageUrl;
            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task<List<Categoria>> GetAll()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria?> GetById(int id)
        {
            return await _context.Categorias
                .SingleOrDefaultAsync(c => c.CategoriaId == id);
        }
    }
}