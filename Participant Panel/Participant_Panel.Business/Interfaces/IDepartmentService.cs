using Participant_Panel.Common.ResponseObjects;
using Participant_Panel.Dtos.DepartmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Panel.Business.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentListDto>> GetAllAsync();
    }
}
