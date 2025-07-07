using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using DealManagement.Server.Domain.Models;
using DealManagement.Server.Domain.Services;
using DealManagement.Server.Persistence.Contexts;
using AutoMapper;
using DealManagement.Server.Resources;

namespace DealManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealsController : ControllerBase
    {
        private readonly DealContext _context;
        private readonly IDealService _dealService;
        private readonly IValidator<Deal> _dealValidator;
        private readonly IMapper _mapper;

        public DealsController(DealContext context, IValidator<Deal> validator, IDealService dealService, IMapper mapper)
        {
            _context = context;
            _dealValidator = validator;
            _dealService = dealService;
            _mapper = mapper;
        }

        // Fix for CS0029: Wrap the result of _dealService.ListAsync() in Ok() to return it as an ActionResult.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deal>>> GetDeals()
        {
            var deals = await _dealService.ListAsync();
            var resources =  _mapper.Map<IEnumerable<Deal>, IEnumerable<DealResource>>(deals);
            return Ok(resources);
        }

        // GET: api/Deals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deal>> GetDeal(string id)
        {
            var deal = await _context.Deals.FindAsync(id);

            if (deal == null)
            {
                return NotFound();
            }

            return deal;
        }

        // PUT: api/Deals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeal(string id, Deal deal)
        {
            if (id != deal.Slug)
            {
                return BadRequest();
            }

            // Validate the deal using FluentValidation
            try
            {
                _dealValidator.ValidateAndThrow(deal);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

            _context.Entry(deal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealExists(id))
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

        // POST: api/Deals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deal>> PostDeal(Deal deal)
        {

            // Validate the deal using FluentValidation
            try
            {
                _dealValidator.ValidateAndThrow(deal);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }

            _context.Deals.Add(deal);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DealExists(deal.Slug))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDeal", new { id = deal.Slug }, deal);
        }

        // DELETE: api/Deals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeal(string id)
        {
            var deal = await _context.Deals.FindAsync(id);
            if (deal == null)
            {
                return NotFound();
            }

            _context.Deals.Remove(deal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DealExists(string id)
        {
            return _context.Deals.Any(e => e.Slug == id);
        }
    }
}
