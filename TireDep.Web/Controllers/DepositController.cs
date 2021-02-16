using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        public DepositController(IDepositService depositService, ILogger<DepositController> logger,
            IOwnerService ownerService)
        {
            _depositService = depositService;
            _logger = logger;
            _ownerService = ownerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _depositService.GetAllDepositForList(4, 1, "", "");
            _logger.LogInformation("wyświtlenie indexu");
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString, string searchStringOwnerName)
        {
            _logger.LogInformation("Uzycie stronnicowania lub searchbox");
            pageNo ??= 1;
            searchString ??= String.Empty;
            searchStringOwnerName ??= String.Empty;
            var model = _depositService.GetAllDepositForList(pageSize, pageNo.Value, searchString, searchStringOwnerName);
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
                return RedirectToAction("ViewDepositById", "Deposit", new {id = id});
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
        [Authorize]

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult AddDepositNewUser(NewDepositVm model)
        {
            //if (ModelState.IsValid)
            //{
                var SelectedSeason = model.SeasonTireId;
            ViewBag.SelectedSeason = model.SeasonTireId;
            var id = _depositService.AddDeposit(model);
            return RedirectToAction("ViewDepositById", "Deposit", new {id = id});
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
        public IActionResult EditDeposit(int id)
        {
            var tyreSeasontype = _depositService.GetSeasonType().SeasonTypeList.ToList();
            ViewBag.Seasons = tyreSeasontype;
            NewDepositVm.TyreSeasonSelectList = new SelectList(tyreSeasontype, "Id", "Name");

            var allOwners = _ownerService.GetAllOwners().Owners.ToList();
            ViewBag.Owners = allOwners;

            NewDepositVm.AllOwners = new SelectList(allOwners, "Id", "LastName");
            var depostToEdit = _depositService.GetDepositToEdit(id);
            return View(depostToEdit);
        }
        [Authorize]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDeposit(NewDepositVm depostToEdit)
        {

            if (ModelState.IsValid)
            {
                var SelectedSeason = depostToEdit.SeasonTireId;
                ViewBag.SelectedSeason = depostToEdit.SeasonTireId;
                var allOwners = _ownerService.GetAllOwners().Owners.ToList();
                int selectedOwner = depostToEdit.OwnerId;
                _depositService.UpdateDeposit(depostToEdit);
                return RedirectToAction("ViewDepositById", "Deposit", new { id = depostToEdit.Id });
            }
            else
            {
                return View(depostToEdit);
            }


        }

        [Authorize]
        public IActionResult ReturnDep(int id)
        {
            var model = _depositService.GetDepToReturn(id);
            _depositService.ReturnDeposit(model);
            return RedirectToAction("ViewDepositById", "Deposit", new { id = model.Id });
        }


      
    }
}
