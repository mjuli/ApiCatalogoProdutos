using Microsoft.AspNetCore.Mvc;
using ApiCatalogoProdutos.Dto.Input;
using ApiCatalogoProdutos.Model;
using ApiCatalogoProdutos.Services;

namespace ApiCatalogoProdutos.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IProdutoService service)
        {
            try
            {
                List<Produto> produtos = await service.GetAll();

                if (produtos == null)
                {
                    return NotFound("Nenhum produto encontrado");
                }

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(
            [FromServices] IProdutoService service,
            [FromRoute] int id)
        {
            try
            {
                Produto? produto = await service.GetById(id);
                if (produto == null)
                {
                    return NotFound("Nenhum produto encontrado com esse id");
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromServices] IProdutoService service,
            [FromBody] ProdutoDto input)
        {
            try
            {
                if (input is null)
                {
                    return BadRequest();
                }
                Produto produto = await service.Create(input);

                return CreatedAtAction(nameof(Create), new { id = produto.ProdutoId }, produto);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound($"{ex.ParamName} não encontrada(o)");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit(
            [FromServices] IProdutoService service,
            [FromRoute] int id,
            [FromBody] ProdutoDto input)
        {
            try
            {
                if (input is null)
                {
                    return BadRequest();
                }

                Produto? produto = await service.Edit(id, input);

                return Ok(produto);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound($"{ex.ParamName} não encontrada(o)");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(
            [FromServices] IProdutoService service,
            [FromRoute] int id)
        {
            try
            {
                await service.Delete(id);

                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound($"{ex.ParamName} não encontrada(o)");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}