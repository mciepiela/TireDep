using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TireDep.App.Interfaces;
using TireDep.App.ViewModels.Deposit;

namespace TireDep.Web.Controllers
{
    public class DepositController : Controller
    {
        private readonly IDepositService _depositService;
        private readonly ILogger<DepositController> _logger;
        public DepositController(IDepositService depositService, ILogger<DepositController> logger)
        {
            _depositService = depositService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _depositService.GetAllDepositForList(4,1,"");
            _logger.LogInformation("wyświtlenie indexu");
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            _logger.LogInformation("Uzycie stronnicowania lub searchbox");
            pageNo ??= 1;
            searchString ??= String.Empty;
            var model = _depositService.GetAllDepositForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }






        [HttpGet]
        public IActionResult AddDeposit()
        {
            _logger.LogInformation("Dodawanie depozytu");
            return View(new NewDepositVm());
            
        }

        [HttpPost]
        public IActionResult AddDeposit(NewDepositVm model)
        {
            var id = _depositService.AddDeposit(model);

            return View(model);
        }


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

        [HttpGet]
        public IActionResult SearchDepositsByOwnerName()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DepositsByOwnerName(string searchString)
        {
            var listOfDepositsByOwnerName = _depositService.ViewDepositsByOwnerName(searchString);

            return View(listOfDepositsByOwnerName);
        }

    }
}
