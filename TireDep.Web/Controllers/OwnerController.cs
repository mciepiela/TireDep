using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TireDep.App.Interfaces;

namespace TireDep.Web.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public IActionResult GetOwnersList()
        {

            return View();
        }
        [HttpGet]
        public IActionResult AddNewOwnerForDeposit(int depositId)
        {
            
            return View();
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
