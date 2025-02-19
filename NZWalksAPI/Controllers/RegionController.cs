using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Data;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NZWalkDbContext _dbContext;
        public RegionController(NZWalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       [HttpGet]
       public IActionResult GetAll()
        {
            var regions = _dbContext.Regions.ToList();

            return Ok(regions);
        }

        [HttpGet]
        [Route("id:Guid")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            //var regions = _dbContext.Regions.Find(id);
            var regions = _dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regions == null) 
            {
                return NotFound();
            }

            return Ok(regions);
        }
    }
}
