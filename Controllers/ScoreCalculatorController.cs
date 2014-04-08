using System.Web.Mvc;
using BowlingScore.Models;
using System.Linq;
using System.Collections.Generic;

namespace BowlingScore.Controllers
{
    public class ScoreCalculatorController : Controller
    {
        [HttpPost]
        public JsonResult Calculate(Frame[] frames)
        {
            List<int> rollsPins = GetRollsPins(frames);

            var game = new BowlingGame();
            foreach (var rollPins in rollsPins)
            {
                game.Roll(rollPins);
            }

            var scoreResult = game.CalculateScore();

            return Json(new { score = scoreResult }, JsonRequestBehavior.AllowGet);
        }

        private static List<int> GetRollsPins(Frame[] frames)
        {
            List<int> rollsPins = new List<int>();
            foreach (var frame in frames)
            {
                if (frame.First != 0)
                    rollsPins.Add(frame.First);

                if (frame.Second != 0)
                    rollsPins.Add(frame.Second);
            }

            return rollsPins;
        }
    }
}
