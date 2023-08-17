using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Participant_Panel.Entites.Domains
{
    public class AppUser : IdentityUser
    {
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(maximumLength: 200)]
        public string? Name { get; set; }

        [Required]
        [StringLength(maximumLength: 200)]
        public string? Surname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(maximumLength: 200)]
        public string? University { get; set; }

        [Required]
        [StringLength(maximumLength: 200)]
        public string? Specialty { get; set; }
        [Required]
        public byte Class { get; set; }

        [StringLength(maximumLength: 2500)]
        public string? Hobbies { get; set; }

        [StringLength(maximumLength: 100)]
        public string? ImageName { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool isDeleted { get; set; }

        public Department? Department { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
