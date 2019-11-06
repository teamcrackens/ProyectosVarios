using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAnimate.Modelos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAnimate.Controllers
{
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly DBContext _context;

        // GET: api/<controller>
        [HttpGet]
        public List<Producto> Get()
        {
            return _context.Productos.ToList<Producto>();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Producto Get(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null)
            {
                return null;
            }
            return producto;

        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Producto producto)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody]Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return producto.id;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var producto = _context.Productos.Find(id);
            _context.Productos.Remove(producto);
            _context.SaveChanges();
        }
    }
}
