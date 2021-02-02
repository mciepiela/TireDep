using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using TireDep.App.Interfaces;
using TireDep.App.ViewModels.Deposit;

namespace TireDep.Web.Controllers
{
    public class DepositController : Controller
    {
        private readonly IDepositService _depositService;
        private readonly ILogger<DepositController> _logger;
        private readonly IOwnerService _ownerService;
        public DepositController(IDepositService depositService, ILogger<DepositController> logger, IOwnerService ownerService)
        {
            _depositService = depositService;
            _logger = logger;
            _ownerService = ownerService;
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
        public IActionResult AddDeposit() // for old user
        {
        
            _logger.LogInformation("Dodawanie depozytu");
            var tyreSeasontype = _depositService.GetSeasonType().SeasonTypeList.ToList();
            ViewBag.Seasons = tyreSeasontype;
            NewDepositVm.TyreSeasonSelectList = new SelectList(tyreSeasontype, "Id", "Name");
            
            var allOwners = _ownerService.GetAllOwners().Owners.ToList();
            ViewBag.Owners = allOwners;
            NewDepositVm.AllOwners = new SelectList(allOwners, "Id", "LastName");
            
            return View(new NewDepositVm());
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDeposit(NewDepositVm model)
        {

            if (ModelState.IsValid)
            {
                var SelectedSeason = model.SeasonTireId;
                ViewBag.SelectedSeason = model.SeasonTireId;
                var allOwners = _ownerService.GetAllOwners().Owners.ToList();
                int selectedOwner = model.OwnerId;
                var id = _depositService.AddDeposit(model);
                return RedirectToAction("ViewDepositById", "Deposit", new { id = id });
            }
            else
            {
                return View(model);
            }

           
        }

        // Add Deposit for NewUser
        [HttpGet]
        public IActionResult AddDepositNewUser() 
        {
            _logger.LogInformation("Dodawanie depozytu dla nowego klienta");
            var tyreSeasontype = _depositService.GetSeasonType().SeasonTypeList.ToList();
            ViewBag.Seasons = tyreSeasontype;
            NewDepositVm.TyreSeasonSelectList = new SelectList(tyreSeasontype, "Id", "Name");
            return View(new NewDepositVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult AddDepositNewUser(NewDepositVm model)
        {
            //if (ModelState.IsValid)
            //{
                var SelectedSeason = model.SeasonTireId;
                ViewBag.SelectedSeason = model.SeasonTireId;
                var id = _depositService.AddDeposit(model);
                return RedirectToAction("ViewDepositById", "Deposit", new { id = id });
        //}
            //else
            //{
            //    return View(model);
            //}
}


        public IActionResult ViewDepositById(int id)
        {
            var model = _depositService.ViewDepositById(id);
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
