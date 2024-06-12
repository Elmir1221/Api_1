using ApiPB101.Data;
using ApiPB101.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPB101.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BookController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpGet("(id)")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var data = await _context.Books.FindAsync(id);

            if (data is null) return NotFound();

            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id is null) return BadRequest();

            var data = await _context.Books.FindAsync(id);

            if (id is null) return BadRequest();

            _context.Remove(data);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Book Books)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Books.AddAsync(Books);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Create", Books);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] Book Books)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var data = await _context.Books.FindAsync(id);

            if (data is null) return BadRequest();

            data.Name = Books.Name;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string search)
        {
            return Ok(search == null ? await _context.Books.ToListAsync() : await _context.Books.Where(m => m.Name.Contains(search)).ToListAsync());
        }
    }
}
