using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Participant_Panel.Dtos.MemberDtos
{
    public class MemberRegisterDto
    {
        [StringLength(maximumLength: 30)]
        public string Name { get; set; }
        [StringLength(maximumLength: 30)]
        public string Surname { get; set; }
        [StringLength(maximumLength: 30)]
        public string Username { get; set; }
        public DateTime DateOfBith { get; set; }
        [StringLength(maximumLength: 20, MinimumLength = 8), DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(maximumLength: 20, MinimumLength = 8), DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }


        public int DepartmentId { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string? University { get; set; }

        [Required]
        [StringLength(maximumLength: 200)]
        public string? Specialty { get; set; }
        [Required]
        public byte Class { get; set; }
    }
}
