using ScoreTracker.Models;
using System.Collections.Generic;

namespace ScoreTracker.Data
{
    public interface IScoreTrackerRepo
    {
        int? GetNumberOfScoresAboveThreshold(int score);
        IEnumerable<ScoreDetails> UpdateScoreForPlayer(string player, int score);
    }
}
