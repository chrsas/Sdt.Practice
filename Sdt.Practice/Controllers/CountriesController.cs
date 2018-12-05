using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sdt.Practice;
using Sdt.Practice.Application.Countries;
using Sdt.Practice.Application.Countries.Dto;
using Sdt.Practice.Data;

namespace Sdt.Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        /// <summary>
        /// 获取国家信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GetCountryOutput> GetCountries([FromQuery]GetCountryInput input, [FromQuery]PageRequest pageRequest)
        {

            return _countryService.GetCountries(input, pageRequest);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public IActionResult GetCountry([FromRoute] int id)
        {
            var country = _countryService.GetCountry(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        //// PUT: api/Countries/5
        [HttpPut("{id}")]
        public IActionResult PutCountry([FromRoute] int id, [FromBody] UpdateCountryInput country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != country.Id)
            {
                return BadRequest();
            }

            _countryService.UpdateCountry(country);

            return Ok();
        }

        //// POST: api/Countries
        [HttpPost]
        public IActionResult PostCountry([FromBody] InsertCountryInput country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _countryService.InsertCountry(country);

            //return CreatedAtAction("GetCountry", new { id = country.Id }, country);
            return Ok();
        }

        //// DELETE: api/Countries/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCountry([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var country = await _context.Countries.FindAsync(id);
        //    if (country == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Countries.Remove(country);
        //    await _context.SaveChangesAsync();

        //    return Ok(country);
        //}

        //private bool CountryExists(int id)
        //{
        //    return _context.Countries.Any(e => e.Id == id);
        //}
    }
}