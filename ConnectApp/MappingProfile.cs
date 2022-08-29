using AutoMapper;
using ConnectApp.Dto;
using ConnectApp.Entities;

namespace ConnectApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SampleA, SampleADto>();
            CreateMap<SampleB, SampleBDto>();
            CreateMap<SampleC, SampleCDto>();
            CreateMap<SampleD, SampleDDto>();
        }
    }
}
