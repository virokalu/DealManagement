using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using DealManagement.Server.Domain.Models;
using DealManagement.Server.Domain.Services;
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
        private readonly IDealService _dealService;
        private readonly IValidator<SaveDealResource> _dealValidator;
        private readonly IMapper _mapper;

        public DealsController(IValidator<SaveDealResource> validator, IDealService dealService, IMapper mapper)
        {
            _dealValidator = validator;
            _dealService = dealService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DealResource>>> GetDeals()
        {
            var deals = await _dealService.ListAsync();
            var resources =  _mapper.Map<IEnumerable<Deal>, IEnumerable<DealResource>>(deals);
            return Ok(resources);
        }

        // GET: api/Deals/slug
        [HttpGet("{id}")]
        public async Task<ActionResult<GetDealResource>> GetDeal(string id)
        {
            var response = await _dealService.FindBySlugAsync(id);
            if (!response.Success)
            {
                return NotFound(ModelExtensions.GetErrorMessages(response.Message));
            }
            var dealResource = _mapper.Map<Deal, GetDealResource>(response.Deal);
            return Ok(dealResource);
        }

        // PUT: api/Deals/slug
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeal(string id, [FromBody] SaveDealResource resource)
        {
            try
            {
                _dealValidator.ValidateAndThrow(resource);
                Deal deal = _mapper.Map<SaveDealResource, Deal>(resource);
                DealResponse response = await _dealService.UpdateAsync(id, deal);
                if (!response.Success)
                {
                    return BadRequest(ModelExtensions.GetErrorMessages(response.Message));
                }
                SaveDealResource dealResource = _mapper.Map<Deal, SaveDealResource>(response.Deal);
                return Ok(dealResource);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ModelExtensions.GetErrorMessages(ex));
            }
        }


        // POST: api/Deals
        [HttpPost]
        public async Task<IActionResult> PostDeal([FromBody] SaveDealResource resource)
        {
            try
            {
                _dealValidator.ValidateAndThrow(resource);
                var deal = _mapper.Map<SaveDealResource, Deal>(resource);
                DealResponse response = await _dealService.SaveAsync(deal);
                if (!response.Success)
                {
                    return BadRequest(ModelExtensions.GetErrorMessages(response.Message));
                }
                var dealResource = _mapper.Map<Deal, GetDealResource>(response.Deal);
                return Ok(dealResource);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ModelExtensions.GetErrorMessages(ex));
            }
        }

        // DELETE: api/Deals/slug
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeal(string id)
        { 
            var response = await _dealService.DeleteAsync(id);
            if (!response.Success)
            {
                return BadRequest(ModelExtensions.GetErrorMessages(response.Message));
            }
            var dealResource = _mapper.Map<Deal, DealResource>(response.Deal);
            return Ok(dealResource);
        }
    }
}
