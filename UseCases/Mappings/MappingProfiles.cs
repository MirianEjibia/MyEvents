using AutoMapper;
using Core;

namespace UseCases.Mappiggs;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Event, Event>();
    }
}