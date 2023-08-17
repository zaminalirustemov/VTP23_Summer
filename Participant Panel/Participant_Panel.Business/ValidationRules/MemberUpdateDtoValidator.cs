using FluentValidation;
using Participant_Panel.Dtos.MemberDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Panel.Business.ValidationRules
{
    public class MemberUpdateDtoValidator : AbstractValidator<MemberUpdateDto>
    {
        public MemberUpdateDtoValidator()
        {

            RuleFor(x => x.DepartmentId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.University).NotEmpty();
            RuleFor(x => x.Specialty).NotEmpty();
            RuleFor(x => x.Class).NotEmpty();
        }
    }
}
