using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gear1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GearController : ControllerBase
    {
        private readonly DataContext _context;
        public GearController(DataContext context){
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Gear>>> Get()
        {
            
            return Ok(await _context.Pirates.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gear>> Get(int id){
            var pirate = await _context.Pirates.FindAsync(id);
            if(pirate == null){
                return BadRequest("Pirate Not Found");
            }
            return Ok(pirate);
        }

        [HttpPost]
        public async Task<ActionResult<List<Gear>>> AddPirate(Gear pirate)
        {
            _context.Pirates.Add(pirate);
            await _context.SaveChangesAsync();

            return Ok(await _context.Pirates.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Gear>>> UpdatePirate(int id,Gear request)
        {
            var geardb = await _context.Pirates.FindAsync(request.Id);
            if(geardb == null){
                return BadRequest("Pirate Not Found");
            }
            geardb.Name = request.Name;
            geardb.Fruit = request.Fruit;
            geardb.Navy = request.Navy;
            geardb.FruitType = request.FruitType;
            
            await _context.SaveChangesAsync();
            
            return Ok(geardb);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Gear>>> Delete(int id){
           var geardb = await _context.Pirates.FindAsync(id);
            if(geardb == null){
                return BadRequest("Pirate Not Found");
            }

            _context.Pirates.Remove(geardb);
            await _context.SaveChangesAsync();

            return Ok(await _context.Pirates.ToListAsync());
        }
    }
}