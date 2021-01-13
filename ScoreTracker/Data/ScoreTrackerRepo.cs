using Newtonsoft.Json;
using ScoreTracker.Models;
using ScoreTracker.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace ScoreTracker.Data
{
    public class ScoreTrackerRepo : IScoreTrackerRepo
    {
        private readonly IFileOperations _fileOperations;

        public ScoreTrackerRepo(IFileOperations fileOperations)
        {
            _fileOperations = fileOperations;
        }

        public int? GetNumberOfScoresAboveThreshold(int score)
        {
            var scoreDetails=ReadAndConvertData();
            return scoreDetails?.Where(s => s.Score > score).ToList().Count;
        }

        public IEnumerable<ScoreDetails> UpdateScoreForPlayer(string player, int score)
        {
            var scoreDetails = ReadAndConvertData();
            var playerScoreObj=scoreDetails.FirstOrDefault(s => s.Player.ToLower().Trim() == player.ToLower().Trim());
            if (playerScoreObj == null) return new List<ScoreDetails>();
            playerScoreObj.Score = score;
            var checkStatus=ConvertAndWriteData(scoreDetails);
            if (!checkStatus) return new List<ScoreDetails>();
            return scoreDetails;

        }

        private IEnumerable<ScoreDetails> ReadAndConvertData()
        {
            var jsonData = _fileOperations.ReadDataFromFileDatabase();
            return JsonConvert.DeserializeObject<IEnumerable<ScoreDetails>>(jsonData);
        }

        private bool ConvertAndWriteData(IEnumerable<ScoreDetails> scoreDetails)
        {
            var updatedJson = JsonConvert.SerializeObject(scoreDetails, Formatting.Indented);
            var checkStatus= _fileOperations.WriteDataToFileDatabase(updatedJson);
            return checkStatus;
        }
    }
}
