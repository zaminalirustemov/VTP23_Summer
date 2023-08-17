using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Participant_Panel.Business.Interfaces;
using Participant_Panel.Dtos.MemberDtos;
using Participant_Panel.Entites.Domains;
using Participant_Panel.UI.Extensions;
using Participant_Panel.UI.Helpers;

namespace Participant_Panel.UI.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IDepartmentService _departmentService;

        public MemberController(IMemberService memberService, IDepartmentService departmentService)
        {
            _memberService = memberService;
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index(string childname,int page=1)
        {
            if (String.IsNullOrEmpty(childname))
            {
                var query = _memberService.GetQueryable();
                var paginatedList = PaginatedList<AppUser>.Create(query, 10, page);
                return View(paginatedList);
            }
            else
            {
                var query = _memberService.GetQueryable().Where(x=>x.Name.Contains(childname));
                var paginatedList = PaginatedList<AppUser>.Create(query, 10, page);
                return View(paginatedList);
            }
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Departments = await _departmentService.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MemberCreateDto memberCreateDto)
        {
            ViewBag.Departments = await _departmentService.GetAllAsync();
            var response = await _memberService.CreateAsync(memberCreateDto);
            return this.ResponseRedirectToAction(response, nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            ViewBag.Departments = await _departmentService.GetAllAsync();
            var response = await _memberService.GetByIdAsync<MemberUpdateDto>(id);
            return this.ResponseView(response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(MemberUpdateDto memberUpdateDto)
        {
            ViewBag.Departments = await _departmentService.GetAllAsync();
            var response = await _memberService.UpdateAsync(memberUpdateDto);
            return this.ResponseRedirectToAction(response, nameof(Index));
        }

        public async Task<IActionResult> Remove(string id)
        {
            var respone = await _memberService.RemoveAsync(id);
            return this.ResponseRedirectToAction(respone, nameof(Index));
        }

        //---------------------------------
        public async Task<IActionResult> IndexIT(string childname, int page = 1)
        {
            var query = _memberService.GetQueryable().Where(x => x.DepartmentId == 1);
            var paginatedList = PaginatedList<AppUser>.Create(query, 10, page);
            return View(paginatedList);
        }
        public async Task<IActionResult> IndexAccounting(string childname, int page = 1)
        {
            var query = _memberService.GetQueryable().Where(x => x.DepartmentId == 2);
            var paginatedList = PaginatedList<AppUser>.Create(query, 10, page);
            return View(paginatedList);
        }
        public async Task<IActionResult> IndexHumanResources(string childname, int page = 1)
        {
            var query = _memberService.GetQueryable().Where(x => x.DepartmentId == 3);
            var paginatedList = PaginatedList<AppUser>.Create(query, 10, page);
            return View(paginatedList);
        }
        public async Task<IActionResult> IndexProcurementLogistics(string childname, int page = 1)
        {
            var query = _memberService.GetQueryable().Where(x => x.DepartmentId == 4);
            var paginatedList = PaginatedList<AppUser>.Create(query, 10, page);
            return View(paginatedList);
        }
        public async Task<IActionResult> IndexRoadConstructionEngineering(string childname, int page = 5)
        {
            var query = _memberService.GetQueryable().Where(x => x.DepartmentId == 2);
            var paginatedList = PaginatedList<AppUser>.Create(query, 10, page);
            return View(paginatedList);
        }
        public async Task<IActionResult> IndexDigitalMarketing(string childname, int page = 1)
        {
            var query = _memberService.GetQueryable().Where(x => x.DepartmentId == 6);
            var paginatedList = PaginatedList<AppUser>.Create(query, 10, page);
            return View(paginatedList);
        }

    }
}
