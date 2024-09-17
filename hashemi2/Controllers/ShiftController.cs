using AutoMapper;
using hashemi2.Core.DbContext;
using hashemi2.Core.Dtos;
using hashemi2.Core.Entities;
using hashemi2.Migrations.MyDb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hashemi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public ShiftController(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //shifts
        [HttpGet]
        [Route("getshift")]
        public async Task<ActionResult<shift>> GetShift()
        {
            var shift = await _context.Shifts.ToListAsync();

            return Ok(shift);
        }

        [HttpPost]
        [Route("createshift")]
        public async Task<IActionResult> CreeateShift([FromBody] ShiftDto shiftDto)
        {
            var shift = new Shift();

            _mapper.Map(shiftDto, shift);

            await _context.Shifts.AddAsync(shift);
            await _context.SaveChangesAsync();
            return Ok("shift save successfully");
        }

        //user shifts
        [HttpGet]
        [Route("getusershift")]
        public async Task<ActionResult<UserShift>> GetUserShift()
        {
            var userShifts = await _context.UserShifts.Include(us => us.USerShift).ToListAsync();

            return Ok(userShifts);
        }

        [HttpGet]
        [Route("getusershiftsingle/{name}")]
        public async Task<ActionResult<UserShift>> GetUserShiftSingle([FromRoute] string name)
        {
            var usershift = await _context.UserShifts.Include(us => us.USerShift).Where(s => s.UserName == name).ToListAsync();
            
            if (usershift == null)
            {
                return NotFound("good not found");
            }
            return Ok(usershift);
        }
        [HttpPost]
        [Route("createusershift")]
        public async Task<IActionResult> CreateUserShift([FromBody] UserShiftDto userShiftDto)
        {
            var userShift = new UserShift();
            _mapper.Map(userShiftDto, userShift);

            await _context.UserShifts.AddAsync(userShift);
            await _context.SaveChangesAsync();

            return Ok("userShift add successfully");
        }


    }
}
