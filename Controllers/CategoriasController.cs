using ApiCatalogoProdutos.Dto.Input;
using ApiCatalogoProdutos.Model;
using ApiCatalogoProdutos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoProdutos.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] ICategoriaService service)
        {
            try
            {
                List<Categoria> categorias = await service.GetAll();

                if (categorias == null)
                {
                    return NotFound("Nenhuma categoria encontrada");
                }

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromServices] ICategoriaService service,
            [FromBody] CategoriaDto input)
        {
            try
            {
                if (input is null)
                    return BadRequest();

                Categoria categoria = await service.Create(input);

                return CreatedAtAction(nameof(Create), new { id = categoria.CategoriaId }, categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(
            [FromServices] ICategoriaService service,
            [FromRoute] int id)
        {
            try
            {
                Categoria? categoria = await service.GetById(id);
                if (categoria == null)
                    return NotFound("Categoria não encontrada");

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit(
            [FromServices] ICategoriaService service,
            [FromRoute] int id,
            [FromBody] CategoriaDto input)
        {
            try
            {
                Categoria? categoria = await service.Edit(id, input);

                return Ok(categoria);

            }
            catch (ArgumentNullException)
            {
                return NotFound("Categoria não localizada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id:int}/produtos")]
        public async Task<IActionResult> GetProdutos(
            [FromServices] ICategoriaService service,
            [FromRoute] int id)
        {
            try
            {
                Categoria? categoria = await service.GetById(id);

                if (categoria == null)
                    return NotFound("Categoria não encontrada");

                return Ok(categoria.Produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(
            [FromServices] ICategoriaService service,
            [FromRoute] int id)
        {
            try
            {
                await service.Delete(id);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound("Categoria não localizada");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}