using Microsoft.AspNetCore.Http;
using Participant_Panel.Dtos.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Participant_Panel.Dtos.MemberDtos
{
    public class MemberCreateDto : IDto
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
        public IFormFile? ImageFile { get; set; }
    }
}
