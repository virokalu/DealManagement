using AutoMapper;
using DealManagement.Server.Domain.Models;
using DealManagement.Server.Resources;

namespace DealManagement.Server.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile() {
            CreateMap<SaveDealResource, Deal>();
        }

    }
}
