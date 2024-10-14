using AutoMapper;
using Core.DTO;
using Infrastructure.Database.Entities;

namespace GradeMS.MappingProfile
{
    public class MappingProfile : Profile
    { 
        public MappingProfile()
        {
            _ = CreateMap<GradeEntityDTO, Grade>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            _ = CreateMap<Grade, GradeEntityDTO>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
