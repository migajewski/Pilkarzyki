﻿using Commands.Match;
using CQRSCore.Commands;
using CQRSCore.Validators;
using Simple.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using Web.Models;

namespace Web.Controllers
{
    public class MatchController : Controller
    {
        private readonly ICommandBus _commandBus;

        public MatchController(ICommandBus commandBus)
        {
            this._commandBus = commandBus;
        }

        public ActionResult Index()
        {
            IEnumerable<MatchModel> matches = Database.Open().MatchList.All();

            return View(matches.Reverse());
        }

        public ActionResult HallOfFame()
        {
            IEnumerable<TeamScoreModel> scores = Database.Open().TeamScores.All();

            // OrderBy tutaj, ponieważ SQL nie lubi OrderBy w widokach
            return View(scores.OrderByDescending(x => x.SumScore));
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

                _commandBus.SendCommand(command);

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