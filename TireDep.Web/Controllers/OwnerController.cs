using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TireDep.App.Interfaces;
using TireDep.App.ViewModels.Owner;

namespace TireDep.Web.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public IActionResult Index()
        {
            var list = _ownerService.GetAllOwners();
            return View(list);
        }
        public IActionResult GetOwnersList()
        {
           var list = _ownerService.GetAllOwners();
            return View(list);
        }
        [HttpGet]
        public IActionResult AddNewOwnerForDeposit(int depositId)
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult AddNewOwner()
        {
            return View(new NewOwnerVm());
        }

        [HttpPost]
        public IActionResult AddNewOwner(NewOwnerVm model)
        {
            var id = _ownerService.AddOwner(model);
            return RedirectToAction("Index","Owner");
        }




        //[HttpPost]
        //        public IActionResult AddNewOwnerForDeposit(OwnerModel model)
        //        {
        //            return View();
        //        }
        public IActionResult ViewOwnerById(int id)
        {
            var model = _ownerService.ViewOwnerById(id);
            return View(model);
        }
    }

}
