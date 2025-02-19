using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalk.CustomActionFeature;
using NZWalk.Data;
using NZWalk.Model;
using NZWalk.Repositories;
using NZWalks.Model.Domain;

namespace NZWalk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await _regionRepository.GetAllAsync();

            //var regiondto = new List<RegionDto>();
            //foreach (var regionDomain in regionsDomain)
            //{
            //    regiondto.Add(new RegionDto()
            //    {
            //        Id = regionDomain.Id,
            //        Code = regionDomain.Code,
            //        Name = regionDomain.Name,
            //        RegionImageUrl = regionDomain.RegionImageUrl,

            //    });
            //}
           return Ok(_mapper.Map<List<RegionDto>>(regionsDomain));
         }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain = await _regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            //var regionDto = new RegionDto
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl,
            //};
            return Ok(_mapper.Map<RegionDto>(regionDomain));
        }



        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //    var regionDomaimModel = new Region

            //    {
            //        Code = addRegionRequestDto.Code,
            //        Name = addRegionRequestDto.Name,
            //        RegionImageUrl = addRegionRequestDto.RegionImageUrl
            //    };

            //    await _dbContext.AddAsync(regionDomaimModel);
            //    await _dbContext.SaveChangesAsync();

            //    var regionDto = new RegionDto
            //    {
            //        Id = regionDomaimModel.Id,
            //        Code = regionDomaimModel.Code,
            //        Name = regionDomaimModel.Name,
            //        RegionImageUrl = regionDomaimModel.RegionImageUrl,
            //    };
            
                var regionMDomainModel = _mapper.Map<Region>(addRegionRequestDto);

                regionMDomainModel = await _regionRepository.CreateAsync(regionMDomainModel);

                var regionDto = _mapper.Map<RegionDto>(regionMDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);

            }
            

            
        

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //var regionDomainModel = new Region
            //{
            //    Code = updateRegionRequestDto.Code,
            //    Name = updateRegionRequestDto.Name,
            //    RegionImageUrl = updateRegionRequestDto.RegionImageUrl,
            //};

            //regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);

            //if (regionDomainModel == null)
            //{
            //    return NotFound();
            //}
            //await _dbContext.SaveChangesAsync();

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl,
            //};
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDto);
                regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await _regionRepository.DeleteAsync(id);
            if (regionDomainModel == null) 
            {
                return NotFound();
            }

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl,
            //};

            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}

