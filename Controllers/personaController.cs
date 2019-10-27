using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using registroPersonas.API.Data;
using Microsoft.EntityFrameworkCore;
using registroPersonas.API.Models;

namespace registroPersonas.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class personaController : ControllerBase 
    {
        private readonly DataContext _context;
        public personaController(DataContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var personas = await _context.Personas.ToListAsync();
            return Ok(personas);
            
        }
        
         [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {

            var persona = await _context.Personas.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }
            return persona;
        }


        [HttpPost]
        public async Task<ActionResult<Persona>>PostPersona(Persona item)
        {
            _context.Personas.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPersona), new { Id = item.Id }, item);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);

            if (persona==null)
            {
                return NotFound();
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();

        }





}
}