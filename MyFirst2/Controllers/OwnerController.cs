using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Abstractions;
using Microsoft.VisualBasic;
using MyFirst2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirst2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase

    {
        private readonly PhoneOwnerDbContext _context;

        public OwnerController(PhoneOwnerDbContext context)
        {
            _context = context;
        }
        // GET: api/<OwnerController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owner>>> Get()
        {
            var Owner = _context.Owners;
            if(Owner != null)
            {
                return Ok(Owner);
            }
            return BadRequest();
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> Get(int id)
        {
           var owner=_context.Owners.FindAsync(id);
            if (owner !=null)
            {
                return Ok(owner);
            }
            return BadRequest();
        }

        // POST api/<OwnerController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Owner model)
        {
            if(ModelState.IsValid)
            {
                await _context.Owners.AddAsync(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Owner model)
        {
            if(model!=null|| model.Id != id)
            {
                return BadRequest();
            }
            _context.Owners.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner != null)
            {
                _context.Owners.Remove(owner);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
