using AutoMapper;
using hashemi2.Core.DbContext;
using hashemi2.Core.Dtos;
using hashemi2.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hashemi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public StockController(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Stock
        [HttpGet]
        [Route("get-stocks")]
        public async Task<ActionResult<IEnumerable<Stock>>> GetAllStocks()
        {
            var stock = await _context.Stocks.Include(g => g.Goods).ToListAsync();

            return Ok(stock);
        }
        [HttpPost]
        [Route("createstock")]
        public async Task<IActionResult> CreateStock([FromBody]StockDto stockDto)
        {
            var stock = new Stock();

            _mapper.Map(stockDto, stock);

            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return Ok("stock saved successfully");
        }
        [HttpGet]
        [Route("getstockbyid/{id}")]
        public async Task<ActionResult<StockDto>> GetStockById([FromRoute] int id)
        {
            var stock = await _context.Stocks.Include(g => g.Goods).FirstOrDefaultAsync(s =>s.Id == id);
            if (stock == null)
            {
                return NotFound("stock not found");
            }
            var convertedStock = _mapper.Map<StockDto>(stock);
            return Ok(convertedStock);
        }
        [HttpPut]
        [Route("editstock/{id}")]
        public async Task<IActionResult> EditStock([FromRoute]int id, [FromBody]StockDto stockDto)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if (stock == null)
            {
                return NotFound();
            }
            _mapper.Map(stockDto, stock);
            await _context.SaveChangesAsync();

            return Ok("stock update successfully");
        }
        [HttpDelete]
        [Route("deletestock/{id}")]
        public async Task<IActionResult> DeleteStock([FromRoute] int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if (stock == null)
            {
                return NotFound("stock not found");
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return Ok("stock deleted successfully");
        }
        //Good
        [HttpGet]
        [Route("getallgoods")]
        public async Task<ActionResult<IEnumerable<Good>>> GetAllGoods()
        {

            var good = await _context.Goods.ToListAsync();



            return Ok(good);
        }


        [HttpPost]
        [Route("creategood")]
        public async Task<IActionResult> CreateGood([FromBody] GoodDto goodDto)
        {
            var good = new Good();
            _mapper.Map(goodDto, good);

            await _context.Goods.AddAsync(good);
            await _context.SaveChangesAsync();
            return Ok("good saved successfully");
        }


        [HttpGet]
        [Route("getgoodbyid/{id}")]
        public async Task<ActionResult> GetGoodById([FromRoute] int id)
        {
            var good = await _context.Goods.FirstOrDefaultAsync(s => s.Id == id);
            if (good == null)
            {
                return NotFound("good not found");
            }
            var convertgood = _mapper.Map<GoodDto>(good);
            return Ok(convertgood);
        }

        [HttpPut]
        [Route("editgood/{id}")]
        public async Task<IActionResult> EditGood([FromRoute] int id, [FromBody] GoodDto goodDto)
        {
            var good = await _context.Goods.FirstOrDefaultAsync(s => s.Id == id);
            if (good == null)
            {
                return NotFound("good not found");
            }
            _mapper.Map(goodDto,good);
            await _context.SaveChangesAsync();

            return Ok("good update successfully");
        }
        [HttpDelete]
        [Route("deletegood/{id}")]
        public async Task<IActionResult> DeleteGood([FromRoute] int id)
        {
            var good = await _context.Goods.FirstOrDefaultAsync(s => s.Id == id);
            if (good == null)
            {
                return NotFound("good not found");
            }

            _context.Goods.Remove(good);
            await _context.SaveChangesAsync();

            return Ok("good deleted successfully");
        }
        [HttpGet]
        [Route("getstockgoods/{id}")]
        public async Task<ActionResult<IEnumerable<Good>>> GetStockGoods([FromRoute] int id)
        {
            var good = await _context.Goods.Where(s => s.StockId == id).ToListAsync();
            if (good == null)
            {
                return NotFound("good not found");
            }
            return Ok(good);
        }
    }
}
