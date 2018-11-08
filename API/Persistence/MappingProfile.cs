using API.Models;
using AutoMapper;

namespace API.Persistence
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDto, Employee>()
                .ForMember(e => e.Id, opt => opt.Ignore());

            CreateMap<Employee, EmployeeDto>();

            CreateMap<ItemDto, Item>()
                .ForMember(i => i.Id, opt => opt.Ignore());

            CreateMap<Item, ItemDto>();
        }
    }
}