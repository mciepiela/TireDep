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
        public IActionResult Index(int pageSize, int? pageNo, string searchString, string searchStringOwnerName)
        {
            _logger.LogInformation("Uzycie stronnicowania");
            pageNo ??= 1;
            pageSize = pageSize == 0 ? 6 : pageSize;
            searchString ??= String.Empty;
            searchStringOwnerName ??= String.Empty;
            var model = _depositService.GetAllDepositForList(pageSize, pageNo.Value, searchString, searchStringOwnerName);
            return View(model);
        }
   

        [HttpGet]
        public IActionResult AddDeposit() // for old user
        {

            
            var tyreSeasontype = _depositService.GetSeasonType().SeasonTypeList.ToList();
            ViewBag.Seasons = tyreSeasontype;
            DepositOwnerVm.TyreSeasonSelectList = new SelectList(tyreSeasontype, "Id", "Name");

            var allOwners = _ownerService.GetAllOwners().Owners.ToList();
            ViewBag.Owners = allOwners;
            DepositOwnerVm.AllOwners = new SelectList(allOwners, "Id", "LastName");
            _logger.LogInformation("Dodawanie depozytu");
            return View(new DepositOwnerVm());

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDeposit(DepositOwnerVm model)
        {
            

            //if (ModelState.IsValid)
            //{
                var SelectedSeason = model.Deposit.SeasonTireId;
                ViewBag.SelectedSeason = model.Deposit.SeasonTireId;
                var allOwners = _ownerService.GetAllOwners().Owners.ToList();
                int selectedOwner = model.Deposit.OwnerId;
                //model.Season.Id = model.Deposit.SeasonTireId;
                var id = _depositService.AddDepositExistedUser(model);
                _logger.LogInformation("Dodawanie depozytu dla starego klienta");
            return RedirectToAction("ViewDepositById", "Deposit", new { id = id });
      
        }

        // Add Deposit for NewUser
        [HttpGet]
        public IActionResult AddDepositNewUser()
        {
            _logger.LogInformation("Dodawanie depozytu dla nowego klienta");
            var tyreSeasontype = _depositService.GetSeasonType().SeasonTypeList.ToList();
            ViewBag.Seasons = tyreSeasontype;
            DepositOwnerVm.TyreSeasonSelectList = new SelectList(tyreSeasontype, "Id", "Name");
            return View(new DepositOwnerVm());
        }
        [Authorize]

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult AddDepositNewUser(DepositOwnerVm model)
        {
            //if (ModelState.IsValid)
            //{
            var SelectedSeason = model.Deposit.SeasonTireId;
            ViewBag.SelectedSeason = model.Deposit.SeasonTireId;
            var id = _depositService.AddDeposit(model);
            return RedirectToAction("ViewDepositById", "Deposit", new {id = id});
            //}
            //else
            //{
            //    return View(model);
            //}
        }

        [HttpGet]
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
            DepositOwnerVm.TyreSeasonSelectList = new SelectList(tyreSeasontype, "Id", "Name");

            var allOwners = _ownerService.GetAllOwners().Owners.ToList();
            ViewBag.Owners = allOwners;
            DepositOwnerVm.AllOwners = new SelectList(allOwners, "Id", "LastName");
            var depostToEdit = _depositService.GetDepositToEdit(id);
            return View(depostToEdit);
        } 
        
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDeposit(DepositOwnerVm depostToEdit)
        {
            if (ModelState.IsValid)
            {
                var owner = _ownerService.GetOwner(depostToEdit.Owner.Id);
                var contact = _ownerService.GetContactByOwnerId(depostToEdit.Owner.Id);
                var season = _depositService.GetSelectecSeason(depostToEdit.Season.Id);
                depostToEdit.Owner = owner;
                depostToEdit.Contact = contact;
                depostToEdit.Season = season;
                depostToEdit.Deposit.OwnerId = owner.Id;
                depostToEdit.Deposit.SeasonTireId = season.Id;
                depostToEdit.Owner.ContactId = contact.Id;
                //depostToEdit.Contact.OwnerRef = 
                //var SelectedSeason = depostToEdit.Season.Id;
                //ViewBag.SelectedSeason = depostToEdit.Deposit.SeasonTireId;
                //var allOwners = _ownerService.GetAllOwners().Owners.ToList();
                //ViewBag.
                //int selectedOwner = depostToEdit.Owner.Id;
                _depositService.UpdateDeposit(depostToEdit);
                return RedirectToAction("ViewDepositById", "Deposit", new { id = depostToEdit.Deposit.Id });
            }
            else
            {
                throw new ArgumentException("Incorrect model.");
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
