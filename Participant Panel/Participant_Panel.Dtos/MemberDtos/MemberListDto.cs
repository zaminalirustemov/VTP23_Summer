using Participant_Panel.Dtos.Interfaces;

namespace Participant_Panel.Dtos.MemberDtos
{
    public class MemberListDto : IDto
    {
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? University { get; set; }
        public string? Specialty { get; set; }
        public byte Class { get; set; }
        public string? Hobbies { get; set; }
        public string? ImageName { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
