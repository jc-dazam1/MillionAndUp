using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.TeamFoundation.Common;
using Microsoft.VisualStudio.Services.WebApi;
using MillionAndUp.Models;

namespace MillionAndUp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly ApiContext _context;

        public PropertiesController(ApiContext context)
        {
            _context = context;
        }



        // GET: api/Properties
        [HttpGet]
        [Route("GetAllProperties")]
        public async Task<ActionResult<IEnumerable<Property>>> GetProperties()
        {
          if (_context.Properties == null)
          {
              return NotFound();
          }
            return await _context.Properties.ToListAsync();
        }

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(Guid id)
        {
          if (_context.Properties == null)
          {
              return NotFound();
          }
            var @property = await _context.Properties.FindAsync(id);

            if (@property == null)
            {
                return NotFound();
            }

            return @property;
        }

        [HttpGet]
        [Route("GetPropertiesFilter")]
        public Task<ActionResult<Property>> GetPropertyFilter([FromQuery] Property filter)
        {

            if (filter == null || IsEmptyObject(filter))
            {
                return Task.FromResult<ActionResult<Property>>(BadRequest("Error empty filter"));
            }


            var resultados = _context.Properties.AsQueryable();

            if (filter.IdOwner != null)
            {
                resultados = resultados.Where(e => e.IdOwner == filter.IdOwner);
            }
           

            if (!string.IsNullOrEmpty(filter.Year))
            {
                resultados = resultados.Where(e => e.Year.Contains(filter.Year));
            }
           

            if (!string.IsNullOrEmpty(filter.Name))
            {
                resultados = resultados.Where(e => e.Name.Contains(filter.Name));
            }
          
            if (!string.IsNullOrEmpty(filter.CodeInternal))
            {
                resultados = resultados.Where(e => e.CodeInternal.Contains(filter.CodeInternal));
            }
           

            if (filter.Price > 0)
            {
                resultados = resultados.Where(e => e.Price == filter.Price);
            }
           


            return Task.FromResult<ActionResult<Property>>(Ok(resultados));
        }

        private bool IsEmptyObject(object obj)
        {
            return obj.GetType().GetProperties().All(property => property.GetValue(obj) == null);
        }




        [HttpPut("{id}")]
        public IActionResult UpdateProperty(Guid id, [FromBody] Property propertyUpdateModel)
        {
            var existingProperty = _context.Properties.Find(id);
            if (existingProperty == null)
            {
                return NotFound();
            }
            existingProperty.Name = propertyUpdateModel.Name;
            existingProperty.Price = propertyUpdateModel.Price;
            existingProperty.CodeInternal = propertyUpdateModel.CodeInternal;
            existingProperty.Address = propertyUpdateModel.Address;
            existingProperty.Year = propertyUpdateModel.Year;
            existingProperty.IdOwner = propertyUpdateModel.IdOwner;


            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("Property/{id}")]
        public IActionResult UpdatePriceProperty(Guid id, [FromBody] Property propertyUpdateModel)
        {
            var existingProperty = _context.Properties.Find(id);
            if (existingProperty == null)
            {
                return NotFound();
            }
            existingProperty.Price = propertyUpdateModel.Price;

            _context.SaveChanges();

            return Ok();
        }

       




        // POST: api/Properties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Property>> PostProperty(Property @property)
        {
          if (_context.Properties == null)
          {
              return Problem("Entity set 'ApiContext.Properties'  is null.");
          }
            _context.Properties.Add(@property);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProperty", new { id = @property.IdProperty }, @property);
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(Guid id)
        {
            if (_context.Properties == null)
            {
                return NotFound();
            }
            var @property = await _context.Properties.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }

            _context.Properties.Remove(@property);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
