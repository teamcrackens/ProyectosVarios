using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Ventas;
using Sistema.Web2.Models.Ventas.Persona;

namespace Sistema.Web2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public PersonasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Personas/ListarClientes
        [Authorize(Roles = "Vendedor,Administrador")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<PersonaViewModel>> ListarClientes()
        {
            var Persona = await _context.Personas.Where(p => p.tipo_persona == "Cliente").ToListAsync();
            return Persona.Select(p => new PersonaViewModel
            {
                idpersona = p.idpersona,
                tipo_persona = p.tipo_persona,
                tipo_documento = p.tipo_documento,
                num_documento = p.num_documento,
                nombre = p.nombre,
                direccion = p.direccion,
                telefono = p.telefono,
                email = p.email
            });
        }
        // GET: api/Personas/ListarProveedores
        [Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<PersonaViewModel>> ListarProveedores()
        {
            var Persona = await _context.Personas.Where(p => p.tipo_persona == "Proveedor").ToListAsync();
            return Persona.Select(p => new PersonaViewModel
            {
                idpersona = p.idpersona,
                tipo_persona = p.tipo_persona,
                tipo_documento = p.tipo_documento,
                num_documento = p.num_documento,
                nombre = p.nombre,
                direccion = p.direccion,
                telefono = p.telefono,
                email = p.email
            });
        }
        // POST: api/Personas/Crear
        [Authorize(Roles = "Almacenero,Administrador,Vendedor")]
        [HttpPost("[action]")]
        public async Task<ActionResult<Persona>> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            var email = model.email.ToLower();

            if (await _context.Personas.AnyAsync(p => p.email == email))
            {
                return BadRequest("Email Ya existente.");
            }
            Persona persona = new Persona
            {
                tipo_persona = model.tipo_persona,
                tipo_documento = model.tipo_documento,
                num_documento = model.num_documento,
                nombre = model.nombre,
                direccion = model.direccion,
                telefono = model.telefono,
                email = model.email.ToLower()
        };

            _context.Personas.Add(persona);
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
        // PUT: api/Personas/Actualizar/
        [Authorize(Roles = "Almacenero,Administrador,Vendedor")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idpersona <= 0)
            {
                return BadRequest(ModelState);
            }

            var persona = await _context.Personas.FirstOrDefaultAsync(p => p.idpersona == model.idpersona);

            if (persona == null)
            {
                NotFound();
            }
            persona.tipo_persona = model.tipo_persona;
            persona.tipo_documento = model.tipo_documento;
            persona.num_documento = model.num_documento;
            persona.nombre = model.nombre;
            persona.direccion = model.direccion;
            persona.telefono = model.telefono;
            persona.email = model.email.ToLower();

            _context.Entry(persona).State = EntityState.Modified;
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
        // GET: api/Personas/SelectProveedores
        [Authorize(Roles = "Almacenero,Administrador")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectProveedorViewModel>> SelectProveedores()
        {
            var proveedores = await _context.Personas.Where(p => p.tipo_persona == "Proveedor").ToListAsync();
            return proveedores.Select(p => new SelectProveedorViewModel
            {
                idpersona = p.idpersona,
                nombre = p.nombre
            });
        }
        // GET: api/Personas/SelectProveedores
        [Authorize(Roles = "Vendedor,Administrador")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectProveedorViewModel>> SelectClientes()
        {
            var proveedores = await _context.Personas.Where(p => p.tipo_persona == "Cliente").ToListAsync();
            return proveedores.Select(p => new SelectProveedorViewModel
            {
                idpersona = p.idpersona,
                nombre = p.nombre
            });
        }


        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.idpersona == id);
        }
    }
}
