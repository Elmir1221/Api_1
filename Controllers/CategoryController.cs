using ApiPB101.Data;
using ApiPB101.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPB101.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //[HttpGet("ResadBey")]
        //public IActionResult GetNums()
        //{
        //    return BadRequest();
        //}
        //[HttpGet]
        //public IActionResult GetById()
        //{
        //    return Ok();
        //}
        //[HttpGet]
        //public IActionResult GetById(int id)
        //{
        //    return Ok("Programming"+ 5);
        //}

        //[HttpGet("(id)")]
        //public IActionResult GetById([FromRoute] int id)
        //{
        //    return Ok("Programming" + id);
        //}
        //public IActionResult GetAllWithParamets([FromQuery] int id, [FromQuery] string name)
        //{
        //    return Ok();
        //}
        // [HttpPost]
        //public IActionResult FileUpload([FromForm]Test test)
        // {
        //     return Ok();
        // }
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    List<string> categories = new List<string>() { "Web design", "Programming", "Digital MArketing" };
        //    return Ok(categories);
        //}


        //[HttpGet]
        //public IActionResult GetById([FromRoute] int id)
        //{
        //    return Ok("Programming" + id);
        //}
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpGet("(id)")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var data = await _context.Categories.FindAsync(id);

            if (data is null) return NotFound();

            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id is null) return BadRequest();

            var data = await _context.Categories.FindAsync(id);

            if (id is null) return BadRequest();

            _context.Remove(data);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Create",category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] Category category)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);
 
            var data = await _context.Categories.FindAsync(id);
            
            if (data is null) return BadRequest();

            data.Name = category.Name;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string search)
        {
            return Ok( search== null ? await _context.Categories.ToListAsync() : await _context.Categories.Where(m=>m.Name.Contains(search)).ToListAsync());
        }


    }
}
