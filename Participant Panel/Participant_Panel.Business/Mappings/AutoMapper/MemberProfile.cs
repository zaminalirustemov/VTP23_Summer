using AutoMapper;
using Participant_Panel.Dtos.MemberDtos;
using Participant_Panel.Entites.Domains;

namespace Participant_Panel.Business.Mappings.AutoMapper
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<AppUser, MemberListDto>().ReverseMap();
            CreateMap<AppUser, MemberCreateDto>().ReverseMap();
            CreateMap<AppUser, MemberUpdateDto>().ReverseMap();
            CreateMap<MemberUpdateDto, MemberListDto>().ReverseMap();
        }
    }
}
