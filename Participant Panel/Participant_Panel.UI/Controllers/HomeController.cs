using Microsoft.AspNetCore.Mvc;
using Participant_Panel.Business.Interfaces;
using Participant_Panel.Dtos.MemberDtos;

namespace Participant_Panel.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemberService _memberService;

        public HomeController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public IActionResult Index()
        {
            ViewBag.IT=  _memberService.GetQueryable().Where(x=>x.DepartmentId==1);
            ViewBag.Accounting =  _memberService.GetQueryable().Where(x=>x.DepartmentId==2);
            ViewBag.HumanResources =  _memberService.GetQueryable().Where(x=>x.DepartmentId==3);
            ViewBag.ProcurementLogistics =  _memberService.GetQueryable().Where(x=>x.DepartmentId==4);
            ViewBag.RoadConstructionEngineering =  _memberService.GetQueryable().Where(x=>x.DepartmentId==5);
            ViewBag.DigitalMarketing =  _memberService.GetQueryable().Where(x=>x.DepartmentId==6);
            return View();
        }

    }
}