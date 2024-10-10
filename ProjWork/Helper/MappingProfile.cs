using AutoMapper;
using ProjWork.Dto;
using ProjWork.Entities.Order;

namespace ProjWork.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<AddressDto, Address>();
        }
    }
}
