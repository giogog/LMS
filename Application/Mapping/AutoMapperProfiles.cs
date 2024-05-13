using AutoMapper;
using Domain.Dtos;
using Domain.Models;
using Domain.Props;

namespace Application.Mapping;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<ScheduleProperty, TimeDto>();
        CreateMap<Lecture, LectureDto>()
            .ForMember(dest => dest.timeDto, opt => opt.MapFrom(src => src.Schedule));
        CreateMap<Seminar, SeminarDto>()
            .ForMember(dest => dest.timeDto, opt => opt.MapFrom(src => src.Schedule)); ;
    }

}

