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
            var stock = await _context.Stocks.ToListAsync();

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
        public async Task<IActionResult> CreateGood([FromBody]GoodDto goodDto)
        {
            var good = new Good();
            _mapper.Map(goodDto, good);

            await _context.Goods.AddAsync(good);
            await _context.SaveChangesAsync();
            return Ok("good saved successfully");
        }
    }
}
