using AutoMapper;
using Participant_Panel.Business.Interfaces;
using Participant_Panel.Common.Enums;
using Participant_Panel.Common.ResponseObjects;
using Participant_Panel.DataAccess.UnitOfWork;
using Participant_Panel.Dtos.DepartmentDtos;
using Participant_Panel.Dtos.MemberDtos;
using Participant_Panel.Entites.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Panel.Business.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public DepartmentService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<DepartmentListDto>> GetAllAsync()
        {
            var data = await _uow.GetRepository<Department>().GetAllAsync();
            var mappeddata=_mapper.Map<List<DepartmentListDto>>(data);
            return mappeddata;
        }
    }
}
