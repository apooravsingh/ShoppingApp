using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
            if(_context.ProductsInDb.Count() == 0)
            {
                _context.ProductsInDb.Add(new Product { Name = "default product", Price = 0 });
                _context.SaveChanges();
            }
        }

        // GET: api/product
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return _context.ProductsInDb.ToList();
        }

        // GET api/product/5
        [HttpGet("{id}", Name = "GetProduct")]
        public ActionResult<Product> GetById(long id)
        {
            var product = _context.ProductsInDb.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.ProductsInDb.Add(product);
            _context.SaveChanges();

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Product product)
        {
            var prod = _context.ProductsInDb.Find(id);
            if (prod == null)
            {
                return NotFound();
            }
            prod.Name = product.Name;
            prod.Price = product.Price;

            _context.ProductsInDb.Update(prod);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var prod = _context.ProductsInDb.Find(id);
            if (prod == null)
            {
                return NotFound();
            }
            _context.ProductsInDb.Remove(prod);
            _context.SaveChanges();
            return NoContent();

        }


        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
