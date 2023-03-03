using Microsoft.AspNetCore.Mvc;
using MyFirst2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirst2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly PhoneOwnerDbContext _context;

        public PhoneController(PhoneOwnerDbContext context)
        {
            _context = context;
        }

        // GET: api/<PhoneController>
        [HttpGet]
        public async Task< ActionResult<IEnumerable<Phone>>> Get()
        {
            var phone = _context.Phones;
            if(phone != null) { 
                return Ok(phone);
            }
            return NotFound();

        }

        // GET api/<PhoneController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phone>> Get(int id)
        {
            var phone = await _context.Phones.FindAsync(id);
            if(phone != null)
            {
                return Ok(phone);
            }
            return NotFound();
        }

        // POST api/<PhoneController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Phone model)
        {
            if(ModelState.IsValid)
            {
                await _context.Phones.AddAsync(model);
                await _context.SaveChangesAsync();
            }
            return BadRequest();
        }

        // PUT api/<PhoneController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Phone model)
        {
            if (model == null || model.Id != id)
            {
                return BadRequest();
            }
            _context.Phones.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<PhoneController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var phone = await _context.Phones.FindAsync(id);
            if (phone != null)
            {
                _context.Phones.Remove(phone);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
