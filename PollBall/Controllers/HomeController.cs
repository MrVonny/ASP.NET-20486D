using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PollBall.Services;

namespace PollBall.Controllers
{
    public class HomeController : Controller
    {
        public IPollResultSevice pollResult;
        public HomeController(IPollResultSevice pollResult)
        {
            this.pollResult = pollResult;
        }
        public IActionResult Index()
        {
            if (HttpContext.Request.Query.ContainsKey("favorite"))
            {
                StringBuilder result = new StringBuilder();
                SortedDictionary<SelectedGame, int> voteList = pollResult.GetVoteResult();
                foreach (var gameVotes in voteList)
                {
                    result.Append($"Game name: {gameVotes.Key}. Votes: {gameVotes.Value}{Environment.NewLine}");
                }
                return Content(result.ToString());
            }
            return Redirect("poll-questions.html");
            
        }
    }
}