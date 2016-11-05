using Commands.Match;
using CQRSCore.Commands;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class MatchController : Controller
    {
        private readonly ICommandBus commandBus;

        public MatchController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
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
            commandBus.SendCommand(command);

            return RedirectToAction("Index");
        }
    }
}