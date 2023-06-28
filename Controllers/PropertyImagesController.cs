using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MillionAndUp.Models;

namespace MillionAndUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImagesController : ControllerBase
    {
        private readonly ApiContext _context;

        public PropertyImagesController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/PropertyImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyImage>>> GetPropertiesImages()
        {
          if (_context.PropertiesImages == null)
          {
              return NotFound();
          }
            return await _context.PropertiesImages.ToListAsync();
        }

        // GET: api/PropertyImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyImage>> GetPropertyImage(Guid id)
        {
          if (_context.PropertiesImages == null)
          {
              return NotFound();
          }
            var propertyImage = await _context.PropertiesImages.FindAsync(id);

            if (propertyImage == null)
            {
                return NotFound();
            }

            return propertyImage;
        }

        // PUT: api/PropertyImages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyImage(Guid id, PropertyImage propertyImage)
        {
            if (id != propertyImage.IdPropertyImage)
            {
                return BadRequest();
            }

            _context.Entry(propertyImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PropertyImages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PropertyImage>> PostPropertyImage(PropertyImage propertyImage)
        {
          if (_context.PropertiesImages == null)
          {
              return Problem("Entity set 'ApiContext.PropertiesImages'  is null.");
          }
            _context.PropertiesImages.Add(propertyImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPropertyImage", new { id = propertyImage.IdPropertyImage }, propertyImage);
        }

        // DELETE: api/PropertyImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropertyImage(Guid id)
        {
            if (_context.PropertiesImages == null)
            {
                return NotFound();
            }
            var propertyImage = await _context.PropertiesImages.FindAsync(id);
            if (propertyImage == null)
            {
                return NotFound();
            }

            _context.PropertiesImages.Remove(propertyImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertyImageExists(Guid id)
        {
            return (_context.PropertiesImages?.Any(e => e.IdPropertyImage == id)).GetValueOrDefault();
        }
    }
}
