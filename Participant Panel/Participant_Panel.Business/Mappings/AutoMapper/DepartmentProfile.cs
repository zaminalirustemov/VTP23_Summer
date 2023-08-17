using AutoMapper;
using Participant_Panel.Dtos.DepartmentDtos;
using Participant_Panel.Dtos.MemberDtos;
using Participant_Panel.Entites.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Panel.Business.Mappings.AutoMapper
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {

            CreateMap<Department, DepartmentListDto>().ReverseMap();
        }
    }
}
