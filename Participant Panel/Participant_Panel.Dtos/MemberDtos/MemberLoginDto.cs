using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Panel.Dtos.MemberDtos
{
    public class MemberLoginDto
    {
        [Required]
        [StringLength(maximumLength: 30)]
        public string UserName { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
