using AutoMapper;
using DealManagement.Server.Domain.Models;
using DealManagement.Server.Resources;

namespace DealManagement.Server.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Deal, DealResource>();
            CreateMap<Deal, GetDealResource>()
                .ForMember(dest => dest.Hotels, opt => opt.MapFrom(src => src.Hotels));
            CreateMap<Hotel, HotelResource>();
            CreateMap<Hotel, SaveHotelResource>();
        }
    }
}
