using AutoMapper;
using hashemi2.Core.DbContext;
using hashemi2.Core.Dtos;
using hashemi2.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hashemi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestGoodController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public RequestGoodController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration = null, MyDbContext context = null, IMapper mapper = null)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        //events
        [HttpGet]
        [Route("getevents")]
        public async Task<ActionResult<Event>> GetEvents()
        {
            var events = await _context.Events.Include(x => x.Requset).ToListAsync();

            return Ok(events);
        }

        [HttpPost]
        [Route("createevent")]
        public async Task<IActionResult> CreateEvent([FromBody] EventDto eventDto)
        {
            var newevent = new Event();

            _mapper.Map(eventDto,newevent);

            await _context.Events.AddAsync(newevent);
            await _context.SaveChangesAsync();

            return Ok("new event create succeffully");
        }

        [HttpPut]
        [Route("editevent/{id}")]
        public async Task<IActionResult> EditeEvent([FromBody] EventDto eventDto, [FromRoute] int id)
        {
            var newevent = await _context.Events.Include(e => e.Requset).FirstOrDefaultAsync();

            if(newevent == null)
            {
                return NotFound();
            }

            _mapper.Map(eventDto,newevent);
            await _context.SaveChangesAsync();

            return Ok("event edited succeffully");

        }

        [HttpDelete]
        [Route("deleteevent/{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            var delevent = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);

            if (delevent == null)
            {
                return NotFound("event not found");
            }
            _context.Events.Remove(delevent);
            await _context.SaveChangesAsync();
            
            return Ok("event deleted successfully");
        }
    }
}
