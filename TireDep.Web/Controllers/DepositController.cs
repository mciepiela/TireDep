using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TireDep.App.Interfaces;

namespace TireDep.Web.Controllers
{
    public class DepositController : Controller
    {
        private readonly IDepositService _depositService;

        public DepositController(IDepositService depositService)
        {
            _depositService = depositService;
        }

        public IActionResult Index()
        {
            var model = _depositService.GetAllDepositForList();

            return View(model);
        }
        [HttpGet]
        public IActionResult AddDeposit()
        {


            return View();
        }

        //    [HttpPost]
        //    public IActionResult AddDeposit(DepositModel model)
        //    {
        //        var model = depositService.AddDeposit(model);

        //        return View(model);
        //    }


        public IActionResult ViewDepositById(int depositId)
        {
            var model = _depositService.ViewDepositById(depositId);
            return View(model);
        }

        public IActionResult ViewDepositsByOwnerId(int ownerId)
        {
            var model = _depositService.ViewDepositsByOwnerId(ownerId);
            return View(model);
        }

    }
}
