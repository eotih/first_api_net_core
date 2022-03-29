using First_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InforController : ControllerBase
    {
        private readonly Bai1Context _context;

        public InforController(Bai1Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Infor>>> GetInfor()
        {
            return await _context.Infors.ToListAsync();
        }
        // GET: api/Infor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Infor>> GetEmployee(int id)
        {
            var obj = await _context.Infors.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Infor infor)
        {
            if (id != infor.Id)
            {
                return BadRequest();
            }

            _context.Entry(infor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InforExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Infor>> PostInfor(Infor infor)
        {
            if (infor is null)
            {
                throw new ArgumentNullException(nameof(infor));
            }
            _context.Infors.Add(infor);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetInfor", new { id = infor.Id }, infor);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Infor>> Delete(int id)
        {
            var infor = await _context.Infors.FindAsync(id);
            if (infor == null)
            {
                return NotFound();
            }

            _context.Infors.Remove(infor);
            await _context.SaveChangesAsync();

            return infor;
        }

        private bool InforExists(int id)
        {
            return _context.Infors.Any(e => e.Id == id);
        }
    }
}