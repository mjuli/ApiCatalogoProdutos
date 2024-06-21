using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiCatalogoProdutos.Context;
using ApiCatalogoProdutos.Dto.Input;
using ApiCatalogoProdutos.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoProdutos.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Produto> produtos = await _context.Produtos.ToListAsync();

            if (produtos == null)
            {
                return NotFound("Nenhum produto encontrado");
            }

            return Ok(produtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Produto produto = await _context.Produtos.SingleOrDefaultAsync(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound("Nenhum produto encontrado com esse id");
            }

            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProdutoDto input)
        {
            if (input is null)
            {
                return BadRequest();
            }

            Categoria categoria = await _context.Categorias.SingleOrDefaultAsync(c => c.CategoriaId == input.CategoriaId);

            if (categoria is null)
            {
                return NotFound("Categoria não localizada");
            }

            Produto produto = new Produto(input.Nome, input.Descricao, input.Preco, input.ImageUrl, input.CategoriaId);
            if (input.Estoque != null)
                produto.Estoque = (float)input.Estoque;

            await _context.AddAsync(produto);
            categoria.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] ProdutoDto input)
        {
            if (input is null)
            {
                return BadRequest();
            }

            Produto? produto = await _context.Produtos.SingleOrDefaultAsync(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound("Produto não localizado");
            }

            Categoria? categoria = await _context.Categorias.SingleOrDefaultAsync(c => c.CategoriaId == input.CategoriaId);
            if (categoria is null)
            {
                return NotFound("Categoria não localizada");
            }

            produto.Nome = input.Nome;
            produto.Descricao = input.Descricao;
            produto.Preco = input.Preco;
            produto.ImageUrl = input.ImageUrl;
            produto.CategoriaId = input.CategoriaId;

            categoria.Produtos.Add(produto);

            await _context.SaveChangesAsync();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Produto? produto = await _context.Produtos.SingleOrDefaultAsync(p => p.ProdutoId == id);
            if (produto == null)
                return NotFound("Produto não localizado");

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}