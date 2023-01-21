using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET_6_Web_API_Entity_Framework.Core;

namespace NET_6_Web_API_Entity_Framework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _contex;
        public CountriesController(DataContext contex)
        { 
            _contex = contex;
        }
        [HttpGet("Get")]
        public async Task<ActionResult<List<Country>>> Get()
        {
            var products = await _contex.Countries.ToListAsync();

            return Ok(products.OrderBy(x => x.Id).ToList());

        }
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Country>> Get(int id)
        {
            var product = await _contex.Countries.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (product == null)
                return BadRequest("id Bulunamadı");
            return Ok(product);
        }
        [HttpPost("AddProduct")]
        public async Task<ActionResult<List<Country>>> AddProduct(Country entity)
        {
            _contex.Countries.Add(entity);
            await _contex.SaveChangesAsync();
            var products = await _contex.Countries.ToListAsync();
            return Ok(products.OrderBy(x => x.Id).ToList());
        }
        [HttpPut("UpdateProduct")]
        public async Task<ActionResult<List<Country>>> UpdateProduct(Country requeest)
        {

            var product = await _contex.Countries.Where(x => x.Id == requeest.Id).FirstOrDefaultAsync();
            if (product == null)
                return BadRequest("Ürün Bulunamadı");
            product.Name = requeest.Name; 
            await _contex.SaveChangesAsync();
            var products = await _contex.Countries.ToListAsync();
            return Ok(products.OrderBy(x => x.Id).ToList());
        }
        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult<List<Country>>> DeleteProduct(int id)
        {
            var product = await _contex.Countries.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (product == null)
                return BadRequest("Ürün Bulunamadı");
            _contex.Countries.Remove(product);
            await _contex.SaveChangesAsync();
            var products = await _contex.Countries.ToListAsync();
            return Ok(products.OrderBy(x => x.Id).ToList());
        }

    }
}
