using ApiCatalogoProdutos.Context;
using ApiCatalogoProdutos.Dto.Input;
using ApiCatalogoProdutos.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoProdutos.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Categoria> categorias = await _context.Categorias.ToListAsync();

            if (categorias == null){
                return NotFound("Nenhuma categoria encontrada");
            }

            return Ok(categorias);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoriaDto input)
        {
            if(input is null){
                return BadRequest();
            }

            Categoria categoria = new(input.Nome, input.ImageUrl);
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return Created();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Categoria? categoria = await _context.Categorias
                .SingleOrDefaultAsync(c => c.CategoriaId == id);

            if (categoria == null)
                return NotFound("Categoria não encontrada");

            return Ok(categoria);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] CategoriaDto input)
        {
            Categoria? categoria = await _context.Categorias
                .SingleOrDefaultAsync(c => c.CategoriaId == id);

            if (categoria == null)
                return NotFound("Categoria não encontrada");

            categoria.Nome = input.Nome;
            categoria.ImageUrl = input.ImageUrl;
            await _context.SaveChangesAsync();

            return Ok(categoria);
        }

        [HttpGet("{id:int}/produtos")]
        public async Task<IActionResult> GetProdutos([FromRoute] int id)
        {
            Categoria? categoria = await _context.Categorias
                .SingleOrDefaultAsync(c => c.CategoriaId == id);

            if (categoria == null)
                return NotFound("Categoria não encontrada");

            return Ok(categoria.Produtos);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Categoria? categoria = await _context.Categorias
                .SingleOrDefaultAsync(c => c.CategoriaId == id);

            if (categoria == null)
                return NotFound("Categoria não encontrada");

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}