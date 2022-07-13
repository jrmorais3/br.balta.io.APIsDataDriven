using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var products = await context
                .Products
                .Include(x => x.category)
                .AsNoTracking()
                .ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Product>>> GetById(int id, [FromServices] DataContext context)
        {
            var products = await context
                .Products
                .Include(x => x.category)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return Ok(products);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Post([FromBody] Product product, [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                context.Products.Add(product);
                await context.SaveChangesAsync();
                return Ok(product);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível criar o produto!" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Product>>> Put([FromBody] Product product, [FromServices] DataContext context)
        {
            try
            {
                context.Entry<Product>(product).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar a categoria" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Product>>> Delete(int id, [FromServices] DataContext context)
        {
            var products = await context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (products == null)
                return NotFound(new { message = "O id deve ser diferente de nulo" });

            try
            {
                context.Products.Remove(products);
                await context.SaveChangesAsync();
                return Ok(new { message = "Produto excluído com sucesso!" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível excluir o produto" });
            }
        }
    }
}
