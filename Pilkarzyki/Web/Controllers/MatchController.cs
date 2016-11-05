using Commands.Match;
using CQRSCore.Commands;
using CQRSCore.Validators;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class MatchController : Controller
    {
        private readonly ICommandBus commandBus;

        public MatchController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        public ActionResult Index()
        {
            IEnumerable<MatchModel> matches = Database.Open().MatchList.All();

            return View(matches);
        }

        // GET: Match
        public ActionResult Add()
        {
            var db = Database.Open();

            var players = db.Players.All();

            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var player in players)
            {
                listItems.Add(new SelectListItem() { Text = player.Name, Value = player.Id.ToString() });
            }

            return View(listItems);
        }

        [HttpPost]
        public ActionResult Add(AddMatch command)
        {
            try
            {

                commandBus.SendCommand(command);

            }
            catch (ValidationException ex)
            {
                return RedirectToAction("Error", "Match", new { message = ex.Message });
                throw;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Error(string message)
        {
            return View(model : message );
        }
    }
}