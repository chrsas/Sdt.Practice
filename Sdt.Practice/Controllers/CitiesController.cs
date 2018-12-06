using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sdt.Practice.Application.Cities;
using Sdt.Practice.Application.Cities.Dto;
using Sdt.Practice.Application.Countries.Dto;

namespace Sdt.Practice.Controllers
{
    [Route("api/countries/{countryId}/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET
        [HttpGet()]
        public IEnumerable<GetCityOutput> GetCities([FromRoute] int countryId)
        {
            return _cityService.GetCities(countryId).ToList();
        }

        [HttpPost]
        public void PostCities([FromRoute] int countryId, [FromBody] ICollection<InsertCityInput> inputs)
        {
            _cityService.InsertCities(countryId, inputs);
        }

        [HttpGet("{cityId}")]
        public IActionResult GetCity([FromRoute] int countryId, [FromRoute] int cityId)
        {
            var city = _cityService.GetCity(countryId, cityId);
            if (city == null)
                return NotFound();
            return Ok(city);
        }
    }
}