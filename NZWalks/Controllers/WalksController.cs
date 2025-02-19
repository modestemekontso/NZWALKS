using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalk.Data;
using NZWalk.Model;
using NZWalk.Model.Domain;
using NZWalk.Repositories;
using NZWalks.Model.Domain;

namespace NZWalk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;
        public WalksController( IMapper mapper,IWalkRepository walkRepository)
        {
          _mapper = mapper;
          _walkRepository = walkRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
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

            var walkMDomainModel = _mapper.Map<Walk>(addWalkRequestDto);

            await _walkRepository.CreateAsync(walkMDomainModel);
            return Ok(_mapper.Map<Walk>(walkMDomainModel));
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await _walkRepository.GetAllAsync();


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
            return Ok(_mapper.Map<List<WalkDto>>(walksDomainModel));
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await _walkRepository.GetByIdAsync(id);
            if (walkDomainModel == null)
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
            return Ok(_mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
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
            var walkDomainModel = _mapper.Map<Walk>(updateWalkRequestDto);
            walkDomainModel =  await _walkRepository.UpdateAsync(id, walkDomainModel);

            if(walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(walkDomainModel));
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkDomainModel = await _walkRepository.DeleteAsync(id);
            if (deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            //var regionDto = new RegionDto
            //{
            //    Code = regionDomainModel.Code,
            //    Id = regionDomainModel.Id,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl,
            //};

            return Ok(_mapper.Map<WalkDto>(deletedWalkDomainModel));
        }
    }
}
