using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Almacen;
using Sistema.Web2.Models.Almacen.Articulo;

namespace Sistema.Web2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ArticulosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Articulos/Listar
        [Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<ArticuloViewModel>> Listar()
        {
            var Articulos = await _context.Articulos.Include(x => x.categoria).ToListAsync();
            return Articulos.Select(a => new ArticuloViewModel
            {
                idarticulo = a.idarticulo,
                idcategoria = a.idcategoria,
                categoria = a.categoria.nombre,
                codigo = a.codigo,
                nombre = a.nombre,
                stock = a.stock,
                precio_venta = a.precio_venta,
                descripcion = a.descripcion,
                condicion = a.condicion
            });
        }

        // GET: api/Articulos/ListarIngreso/texto
        [Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]/{texto}")]
        public async Task<IEnumerable<ArticuloViewModel>> ListarIngreso([FromRoute] string texto)
        {
            var Articulos = await _context.Articulos.Include(x => x.categoria)
                .Where(a => a.nombre.Contains(texto))
                .Where(a => a.condicion==true)
                .ToListAsync();
            return Articulos.Select(a => new ArticuloViewModel
            {
                idarticulo = a.idarticulo,
                idcategoria = a.idcategoria,
                categoria = a.categoria.nombre,
                codigo = a.codigo,
                nombre = a.nombre,
                stock = a.stock,
                precio_venta = a.precio_venta,
                descripcion = a.descripcion,
                condicion = a.condicion
            });
        }

        // GET: api/Articulos/ListarVenta/texto
        [Authorize(Roles = "Vendedor,Administrador")]
        [HttpGet("[action]/{texto}")]
        public async Task<IEnumerable<ArticuloViewModel>> ListarVenta([FromRoute] string texto)
        {
            var Articulos = await _context.Articulos.Include(x => x.categoria)
                .Where(a => a.nombre.Contains(texto))
                .Where(a => a.condicion == true)
                .Where(a=>a.stock>0)
                .ToListAsync();
            return Articulos.Select(a => new ArticuloViewModel
            {
                idarticulo = a.idarticulo,
                idcategoria = a.idcategoria,
                categoria = a.categoria.nombre,
                codigo = a.codigo,
                nombre = a.nombre,
                stock = a.stock,
                precio_venta = a.precio_venta,
                descripcion = a.descripcion,
                condicion = a.condicion
            });
        }

        // GET: api/Articulos/Mostrar/5
        [Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Articulo>> Mostrar(int id)
        {
            var articulo = await _context.Articulos.Include(a => a.categoria).SingleOrDefaultAsync(a => a.idarticulo==id);

            if (articulo == null)
            {
                return NotFound();
            }

            return Ok(new ArticuloViewModel
            {
                idarticulo = articulo.idarticulo,
                idcategoria = articulo.idcategoria,
                categoria = articulo.categoria.nombre,
                codigo = articulo.codigo,
                nombre = articulo.nombre,
                stock = articulo.stock,
                precio_venta = articulo.precio_venta,
                descripcion = articulo.descripcion,
                condicion = articulo.condicion
            });
        }

        // GET: api/Articulos/BuscarCodigoIngreso/5
        [Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]/{codigo}")]
        public async Task<ActionResult<Articulo>> BuscarCodigoIngreso([FromRoute] string codigo)
        {
            var articulo = await _context.Articulos.Include(a => a.categoria)
                .Where(a => a.condicion == true)
                .SingleOrDefaultAsync(a => a.codigo == codigo);

            if (articulo == null)
            {
                return NotFound();
            }

            return Ok(new ArticuloViewModel
            {
                idarticulo = articulo.idarticulo,
                idcategoria = articulo.idcategoria,
                categoria = articulo.categoria.nombre,
                codigo = articulo.codigo,
                nombre = articulo.nombre,
                stock = articulo.stock,
                precio_venta = articulo.precio_venta,
                descripcion = articulo.descripcion,
                condicion = articulo.condicion
            });
        }

        // GET: api/Articulos/BuscarCodigoVenta/5
        [Authorize(Roles = "Vendedor,Administrador")]
        [HttpGet("[action]/{codigo}")]
        public async Task<ActionResult<Articulo>> BuscarCodigoVenta([FromRoute] string codigo)
        {
            var articulo = await _context.Articulos.Include(a => a.categoria)
                .Where(a => a.condicion == true)
                .Where(a => a.stock > 0)
                .SingleOrDefaultAsync(a => a.codigo == codigo);

            if (articulo == null)
            {
                return NotFound();
            }

            return Ok(new ArticuloViewModel
            {
                idarticulo = articulo.idarticulo,
                idcategoria = articulo.idcategoria,
                categoria = articulo.categoria.nombre,
                codigo = articulo.codigo,
                nombre = articulo.nombre,
                stock = articulo.stock,
                precio_venta = articulo.precio_venta,
                descripcion = articulo.descripcion,
                condicion = articulo.condicion
            });
        }

        // PUT: api/Articulos/Actualizar/
        [Authorize(Roles = "Almacenero,Administrador")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idarticulo <= 0)
            {
                return BadRequest(ModelState);
            }

            var articulo = await _context.Articulos.FirstOrDefaultAsync(a => a.idarticulo == model.idarticulo);

            if (articulo == null)
            {
                NotFound();
            }
            articulo.precio_venta = model.precio_venta;
            articulo.stock = model.stock;
            articulo.idcategoria = model.idcategoria;
            articulo.nombre = model.nombre;
            articulo.descripcion = model.descripcion;

            _context.Entry(articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Guardar en LOG
                return BadRequest();
            }
            return Ok();
        }

        // POST: api/Articulos/Crear
        [Authorize(Roles = "Almacenero,Administrador")]
        [HttpPost("[action]")]
        public async Task<ActionResult<Articulo>> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            Articulo articulo = new Articulo
            {
                precio_venta = model.precio_venta,
                codigo = model.codigo,
                stock = model.stock,
                idcategoria = model.idcategoria,
                nombre = model.nombre,
                descripcion = model.descripcion,
                condicion = true
            };

            _context.Articulos.Add(articulo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
            //return CreatedAtAction("GetCategoria", new { id = categoria.idcategoria }, categoria);
        }
        // PUT: api/Articulos/Desactivar/1
        [Authorize(Roles = "Almacenero,Administrador")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest(ModelState);
            }

            var articulo = await _context.Articulos.FirstOrDefaultAsync(a => a.idarticulo == id);

            if (articulo == null)
            {
                NotFound();
            }

            articulo.condicion = false;
            _context.Entry(articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Guardar en LOG
                return BadRequest();
            }
            return Ok();
        }
        // PUT: api/Articulos/Activar/1
        [Authorize(Roles = "Almacenero,Administrador")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest(ModelState);
            }

            var articulo = await _context.Articulos.FirstOrDefaultAsync(a => a.idarticulo == id);

            if (articulo == null)
            {
                NotFound();
            }

            articulo.condicion = true;
            _context.Entry(articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Guardar en LOG
                return BadRequest();
            }
            return Ok();
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(e => e.idarticulo == id);
        }
    }
}
