using AutoMapper;
using Core;
using UseCases.Events.DTOs;

namespace UseCases.Mappiggs;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Event, Event>();
        CreateMap<CraeteEventDto, Event>();
    }
}