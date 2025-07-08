using AutoMapper;
using DealManagement.Server.Domain.Models;
using DealManagement.Server.Domain.Services;
using DealManagement.Server.Extensions;
using DealManagement.Server.Resources;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DealManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IValidator<SaveHotelResource> _validator;
        private readonly IMapper _mapper;

        public HotelsController(IHotelService hotelService, IValidator<SaveHotelResource> validator, IMapper mapper)
        {
            _hotelService = hotelService;
            _validator = validator;
            _mapper = mapper;
        }

        [HttpGet("{slug}")]
        public async Task<ActionResult<IEnumerable<HotelResource>>> GetHotels(string slug)
        {
            var hotels = await _hotelService.ListAsync(slug);
            var resources = _mapper.Map<IEnumerable<HotelResource>>(hotels);
            return Ok(resources);
        }

        [HttpPost]
        public async Task<ActionResult<HotelResource>> PostHotel([FromBody] SaveHotelResource resource)
        {
            try
            {
                _validator.ValidateAndThrow(resource);
                var hotel = _mapper.Map<SaveHotelResource, Hotel>(resource);
                var response = await _hotelService.SaveAsync(hotel);
                if (!response.Success)
                {
                    return BadRequest(ModelExtensions.GetErrorMessages(response.Message));
                }
                var hotelResource = _mapper.Map<Hotel, HotelResource>(response.Hotel);
                return Ok(hotelResource);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ModelExtensions.GetErrorMessages(ex));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, [FromBody] SaveHotelResource resource)
        {
            try
            {
                _validator.ValidateAndThrow(resource);
                var hotel = _mapper.Map<SaveHotelResource, Hotel>(resource);
                var response = await _hotelService.UpdateAsync(id, hotel);
                if (!response.Success)
                {
                    return BadRequest(ModelExtensions.GetErrorMessages(response.Message));
                }
                var hotelResource = _mapper.Map<Hotel, HotelResource>(response.Hotel);
                return Ok(hotelResource);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ModelExtensions.GetErrorMessages(ex));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var response = await _hotelService.DeleteAsync(id);
            if (!response.Success)
            {
                return BadRequest(ModelExtensions.GetErrorMessages(response.Message));
            }
            var hotelResource = _mapper.Map<Hotel, HotelResource>(response.Hotel);
            return Ok(hotelResource);
        }
    }

}
