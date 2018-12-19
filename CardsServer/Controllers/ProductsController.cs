using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardsServer.CardsDB;
using CardsServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardsServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly CardsContext _context;

        public ProductsController(CardsContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            //Product p = new Product();
            //p.Name = "Grain";
            //p.Price = 3.22d;
            //_context.Add(p);
            //_context.SaveChanges();

            return _context.Products;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _context.Products.SingleOrDefaultAsync(t => t.Id == id);

            if (product == null)
                return BadRequest();

            return Ok(product);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.AddAsync(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != product.Id)
                return BadRequest();
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (IsExist(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        private bool IsExist(int id)
        {
            return _context.Products.Any(g => g.Id == id);
        }
    }
}
