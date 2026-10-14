using AutoMapper;
using Core;
using UseCases.Events.DTOs;
using UseCases.Profiles.DTOs;

namespace UseCases.Mappiggs;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Event, Event>();
        CreateMap<CraeteEventDto, Event>();
        CreateMap<Event, EventDto>()
            .ForMember(e => e.HostName, o=>o.MapFrom(e => 
                e.Participants.FirstOrDefault(e=>e.IsHost)!.User.UserName))
             .ForMember(e => e.HostId, o=>o.MapFrom(e => 
                e.Participants.FirstOrDefault(e=>e.IsHost)!.User.Id));
        CreateMap<EventParticipant, UserProfileDto>()
            .ForMember(e =>e.Id, u=>u.MapFrom(x => x.UserId))
            .ForMember(e => e.UserName, u=>u.MapFrom(x=>x.User.UserName))
            .ForMember(e => e.ImageUrl, u=>u.MapFrom(x=>x.User.ImageUrl));
    }
}