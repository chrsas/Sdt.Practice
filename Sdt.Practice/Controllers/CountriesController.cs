using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sdt.Practice;
using Sdt.Practice.Dto;
using Sdt.Practice.Extentions;
using Sdt.Practice.Models;

namespace Sdt.Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly RestApiContext _context;
        private readonly IMapper _mapper;

        public CountriesController(RestApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取国家信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GetCountryOutput> GetCountries([FromQuery]GetCountryInput input, [FromQuery]PageRequest pageRequest)
        {
            var query = _context.Countries.AsQueryable()
                .WhereIf(!string.IsNullOrWhiteSpace(input.EnglishName), c => c.EnglishName.Contains(input.EnglishName))
                .WhereIf(!string.IsNullOrWhiteSpace(input.ChineseName), c => c.ChineseName.Contains(input.ChineseName));
            query = query.Skip(pageRequest.PageIndex * pageRequest.PageCount).Take(pageRequest.PageCount);
            return _mapper.Map<IEnumerable<GetCountryOutput>>(query.ToList());
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // PUT: api/Countries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry([FromRoute] int id, [FromBody] Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != country.Id)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        [HttpPost]
        public async Task<IActionResult> PostCountry([FromBody] Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return Ok(country);
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}