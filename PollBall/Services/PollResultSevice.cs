using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollBall.Services
{
    public class PollResultSevice : IPollResultSevice
    {

        private Dictionary<SelectedGame, int> selectionVotes;

        public PollResultSevice()
        {
            selectionVotes = new Dictionary<SelectedGame, int>();
        }
        public void AddVote(SelectedGame game)
        {
            if (selectionVotes.ContainsKey(game))
                selectionVotes[game]++;
            else
                selectionVotes.Add(game, 1);
        }

        public SortedDictionary<SelectedGame, int> GetVoteResult()
        {
            return new SortedDictionary<SelectedGame, int>(selectionVotes);
        }
    }
}
