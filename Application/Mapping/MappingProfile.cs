using AutoMapper;
using Domain.Dtos;
using Domain.Models;
using Domain.Props;

namespace Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ScheduleProperty, TimeDto>().ReverseMap();
        CreateMap<Faculty, FacultyDto>().ReverseMap();
        CreateMap<University, UniversityDto>()
            .ForMember(dest => dest.Faculties, opt => opt.MapFrom(src => src.Faculties));
        CreateMap<Lecture, LectureDto>()
            .ForMember(dest => dest.timeDto, opt => opt.MapFrom(src => src.Schedule));
        CreateMap<Seminar, SeminarDto>()
            .ForMember(dest => dest.timeDto, opt => opt.MapFrom(src => src.Schedule)); ;
    }

}

