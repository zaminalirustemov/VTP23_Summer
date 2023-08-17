using Participant_Panel.Common.ResponseObjects;
using Participant_Panel.Dtos.MemberDtos;
using Participant_Panel.Entites.Domains;

namespace Participant_Panel.Business.Interfaces
{
    public interface IMemberService
    {
        Task<IResponse<List<MemberListDto>>> GetAllAsync();
        Task<IResponse<IDto>> GetByIdAsync<IDto>(string id);
        Task<IResponse<MemberCreateDto>> CreateAsync(MemberCreateDto workCreateDto);
        Task<IResponse<MemberUpdateDto>> UpdateAsync(MemberUpdateDto workUpdateDto);
        Task<IResponse> RemoveAsync(string id);
        IQueryable<AppUser> GetQueryable();


    }
}
