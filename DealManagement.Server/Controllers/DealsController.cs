using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using DealManagement.Server.Domain.Models;
using DealManagement.Server.Domain.Services;
using DealManagement.Server.Persistence.Contexts;
using AutoMapper;
using DealManagement.Server.Resources;
using DealManagement.Server.Extensions;
using DealManagement.Server.Domain.Services.Communication;

namespace DealManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealsController : ControllerBase
    {
        private readonly DealContext _context;
        private readonly IDealService _dealService;
        private readonly IValidator<SaveDealResource> _dealValidator;
        private readonly IMapper _mapper;

        public DealsController(DealContext context, IValidator<SaveDealResource> validator, IDealService dealService, IMapper mapper)
        {
            _context = context;
            _dealValidator = validator;
            _dealService = dealService;
            _mapper = mapper;
        }

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
            //try
            //{
            //    _dealValidator.ValidateAndThrow(deal);
            //}
            //catch (ValidationException ex)
            //{
            //    return BadRequest(ex.Message);
            //}

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
        [HttpPost]
        public async Task<IActionResult> PostDeal([FromBody] SaveDealResource resource)
        {
            try
            {
                _dealValidator.ValidateAndThrow(resource);
                var deal = _mapper.Map<SaveDealResource, Deal>(resource);
                SaveDealResponse response = await _dealService.SaveAsync(deal);
                if (!response.Success)
                {
                    return BadRequest(response.Message);
                }
                var dealResource = _mapper.Map<Deal, DealResource>(response.Deal);
                return Ok(dealResource);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ModelValidationExtensions.GetErrorMessages(ex));
            }
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
