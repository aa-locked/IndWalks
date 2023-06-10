using IndWalks.API.Data;
using IndWalks.API.Model.Domain;
using IndWalks.API.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IndWalksDBContext _dbContext;
        public RegionsController(IndWalksDBContext dBContext)
        {
            _dbContext = dBContext;
        }






        [HttpGet]
        public IActionResult GetAll()
        {

            var abc = _dbContext.Regions.ToList();
            if (abc == null)
            {
                return NotFound();
            }
            var def = new List<RegionDTO>();

            foreach (var i in abc)
            {
                def.Add(new RegionDTO()
                {
                    Id = i.Id,
                    Code = i.Code,
                    Name = i.Name,
                    RegionImageUrl = i.RegionImageUrl,
                });
            }
            return Ok(def);
            ////Get Data from Database
            //var resultDomain = _dbContext.Regions.ToList();
            ////Map Domain Model to DTOs

            //var regionDto = new List<RegionDTO>();
            //foreach (var region in resultDomain)
            //{
            //    regionDto.Add(new RegionDTO()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        RegionImageUrl = region.RegionImageUrl,
            //    });
            //}

            // Return DTOs
            //return Ok(regionDto);
        }



        ////Get : https://localhost:portnumber/api/Regions
        ////To Get All The Regions



        ////Post : https://localhost:portnumber/api/Regions
        ////To Save Regions
        //[HttpPost]
        //public IActionResult SaveRegions([FromBody] Region region)
        //{
        //    var RegionObj = new Region()
        //    {
        //        Id = Guid.NewGuid(),
        //        Code = region.Code,
        //        Name = region.Name,
        //        RegionImageUrl = region.RegionImageUrl
        //    };

        //    _dbContext.Regions.Add(RegionObj);
        //    _dbContext.SaveChanges();
        //    //201 
        //    return CreatedAtAction(nameof(GetRegionById), new { id = region.Id }, region);

        //}

        ////Put :https://localhost:portnumber/api/Regions
        ////To Update Data
        //[HttpPut]
        //[Route("id:Guid")]
        //public IActionResult UpdateRegion([FromBody] UpdateRegionFromUser updateRegionFromUser, [FromRoute] Guid id)
        //{
        //    var updateRegion = _dbContext.Regions.Find(id);
        //    if (updateRegion == null)
        //    {
        //        //404
        //        return NotFound();
        //    }
        //    updateRegion.Code = updateRegionFromUser.Code;
        //    updateRegion.Name = updateRegionFromUser.Name;
        //    updateRegion.RegionImageUrl = updateRegionFromUser.RegionImageUrl;
        //    _dbContext.SaveChanges();
        //    return Ok();
        //}






        //[HttpGet]
        //[Route("{id:Guid}")]
        //public IActionResult GetRegionById([FromRoute] Guid id)
        //{
        //    //Find is only works on primary Key
        //    var region1 = _dbContext.Regions.Find(id);

        //    //First Or Default works on All the fields
        //    var region = _dbContext.Regions.FirstOrDefault(x => x.Id == id);
        //    if (region == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(region);
        //}

        ////Post To Create A New Region
        ////Post : https://localhost:portnumber/api/Regions
        //[HttpPost]
        //public IActionResult CreateNewRegion([FromBody] AddRegionReqDTO addRegionReqDTO)
        //{
        //    //Map And Convert DTO To Domain Model
        //    var regionDomainModel = new Region()
        //    {
        //        Code = addRegionReqDTO.Code,
        //        Name = addRegionReqDTO.Name,
        //        RegionImageUrl = addRegionReqDTO.RegionImageUrl,
        //    };

        //    // Use Domain Model To Create Region

        //    _dbContext.Regions.Add(regionDomainModel);
        //    _dbContext.SaveChanges();

        //    //Map RegionDomain To RegionDTO
        //    var region = new RegionDTO()
        //    {
        //        Id = regionDomainModel.Id,
        //        Code = regionDomainModel.Code,
        //        Name = regionDomainModel.Name,
        //        RegionImageUrl = regionDomainModel.RegionImageUrl,
        //    };

        //    // Return Created At Action 201
        //    return CreatedAtAction(nameof(GetRegionById), new { id = region.Id }, region);

        //}

        ////Update Region
        ////Put : https://localhost:portnumber/api/Regions
        //[HttpPut]
        //[Route("{id:Guid}")]
        //public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionReqDTO updateRegionReqDTO)
        //{
        //    var regionDomain = _dbContext.Regions.FirstOrDefault(x => x.Id == id);
        //    if (regionDomain == null)
        //    {
        //        return NotFound();
        //    }

        //    regionDomain.Code = updateRegionReqDTO.Code;
        //    regionDomain.Name = updateRegionReqDTO.Name;
        //    regionDomain.RegionImageUrl = updateRegionReqDTO.RegionImageUrl;
        //    _dbContext.SaveChanges();

        //    var regionDto = new RegionDTO()
        //    {
        //        Id = regionDomain.Id,
        //        Code = regionDomain.Code,
        //        Name = regionDomain.Name,
        //        RegionImageUrl = regionDomain.RegionImageUrl
        //    };
        //    return Ok(regionDto);

        //}

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteRegion([FromRoute] Guid id)
        {
            var domaindata = _dbContext.Regions.FirstOrDefault(rgn => rgn.Id == id);
            if(domaindata==null)
            {
                return NotFound();
            }
            _dbContext.Regions.Remove(domaindata);
            _dbContext.SaveChanges();
            return Ok();

        }
    }
}
