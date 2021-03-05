using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using TireDep.App.Interfaces;
using TireDep.App.ViewModels.Owner;
using TireDep.Domain.Interfaces;

namespace TireDep.Web.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;
        private readonly IOwnerRepository _ownerRepository;

        public OwnerController(IOwnerService ownerService, IOwnerRepository ownerRepository)
        {
            _ownerService = ownerService;
            _ownerRepository = ownerRepository;
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

        [HttpGet]
        public object Search(string phrase)
        {
            return _ownerRepository.GetAllOwnersByLastName(phrase)
                .Select(o => new {id = o.Id, text = o.FirstName + " " + o.LastName});
        }

    }

}
