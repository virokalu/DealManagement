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
        }
    }
}
