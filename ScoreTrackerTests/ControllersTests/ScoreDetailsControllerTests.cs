using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ScoreTracker.Controllers;
using ScoreTracker.Data;
using ScoreTracker.Dtos;
using ScoreTracker.Models;
using System.Collections.Generic;

namespace ScoreTrackerTests.ControllersTests
{
    [TestClass]
    public class ScoreDetailsControllerTests
    {
        [TestMethod]
        public void GetNumberOfScoresforPositiveValueReturnsInteger()
        {
            Mock<IScoreTrackerRepo> mockSourceTrackerRepo = new Mock<IScoreTrackerRepo>();
            mockSourceTrackerRepo.Setup(s => s.GetNumberOfScoresAboveThreshold(It.IsAny<int>())).Returns(5);

            Mock<IMapper> mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<IEnumerable<ScoreDetailsDto>>(It.IsAny<IEnumerable<ScoreDetailsDto>>()));

            ScoreDetailsController scoreController = new ScoreDetailsController(mockSourceTrackerRepo.Object,new NullLogger<ScoreDetailsController>(), mockMapper.Object);
            var result = (OkObjectResult)scoreController.GetNumberOfScoresAboveThreshold(1);
            Assert.AreEqual(5, result.Value); ;
          
        }

        [TestMethod]
        public void GetNumberOfScoresforPositiveValueReturns200StatusCode()
        {
            Mock<IScoreTrackerRepo> mockSourceTrackerRepo = new Mock<IScoreTrackerRepo>();
            mockSourceTrackerRepo.Setup(s => s.GetNumberOfScoresAboveThreshold(It.IsAny<int>())).Returns(5);

            Mock<IMapper> mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<IEnumerable<ScoreDetailsDto>>(It.IsAny<IEnumerable<ScoreDetailsDto>>()));

            ScoreDetailsController scoreController = new ScoreDetailsController(mockSourceTrackerRepo.Object, new NullLogger<ScoreDetailsController>(), mockMapper.Object);
            var result = (OkObjectResult)scoreController.GetNumberOfScoresAboveThreshold(1);
            Assert.AreEqual(200, result.StatusCode); 

        }


        [TestMethod]
        public void GetNumberOfScoresforNegativeValueReturnsInteger()
        {
            Mock<IScoreTrackerRepo> mockSourceTrackerRepo = new Mock<IScoreTrackerRepo>();
            mockSourceTrackerRepo.Setup(s => s.GetNumberOfScoresAboveThreshold(It.IsAny<int>())).Returns(5);

            Mock<IMapper> mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<IEnumerable<ScoreDetailsDto>>(It.IsAny<IEnumerable<ScoreDetailsDto>>()));

            ScoreDetailsController scoreController = new ScoreDetailsController(mockSourceTrackerRepo.Object, new NullLogger<ScoreDetailsController>(), mockMapper.Object);
            var result = (OkObjectResult)scoreController.GetNumberOfScoresAboveThreshold(1);
            Assert.AreEqual(5, result.Value); ;

        }

        [TestMethod]
        public void GetNumberOfScoresforNullValueReturnsNotFoundStatusCode()
        {
            Mock<IScoreTrackerRepo> mockSourceTrackerRepo = new Mock<IScoreTrackerRepo>();
            mockSourceTrackerRepo.Setup(s => s.GetNumberOfScoresAboveThreshold(It.IsAny<int>()));

            Mock<IMapper> mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<IEnumerable<ScoreDetailsDto>>(It.IsAny<IEnumerable<ScoreDetailsDto>>()));

            ScoreDetailsController scoreController = new ScoreDetailsController(mockSourceTrackerRepo.Object, new NullLogger<ScoreDetailsController>(), mockMapper.Object);
            var result = (NotFoundResult)scoreController.GetNumberOfScoresAboveThreshold(1);
            Assert.AreEqual(404, result.StatusCode); ;

        }


        [TestMethod]
        public void UpdatePlayerScoresPositiveValueReturnsOKStatusCode()
        {

            #region expectedData
            ICollection<ScoreDetails> playerScoreList = new List<ScoreDetails>();
            ScoreDetails scoreDetails1 = new ScoreDetails();
            scoreDetails1.Player = "Joe";
            scoreDetails1.Score = 2;
            ScoreDetails scoreDetails2 = new ScoreDetails();
            scoreDetails2.Player = "Jane";
            scoreDetails2.Score = 1;
            ScoreDetails scoreDetails3 = new ScoreDetails();
            scoreDetails3.Player = "Jonny";
            scoreDetails3.Score = 5;
            ScoreDetails scoreDetails4 = new ScoreDetails();
            scoreDetails4.Player = "Jeremy";
            scoreDetails4.Score = 2;

            playerScoreList.Add(scoreDetails1);
            playerScoreList.Add(scoreDetails2);
            playerScoreList.Add(scoreDetails3);
            playerScoreList.Add(scoreDetails4);
            #endregion
            Mock<IScoreTrackerRepo> mockSourceTrackerRepo = new Mock<IScoreTrackerRepo>();
            mockSourceTrackerRepo.Setup(s => s.UpdateScoreForPlayer(It.IsAny<string>(), It.IsAny<int>())).Returns(playerScoreList);

            Mock<IMapper> mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<IEnumerable<ScoreDetailsDto>>(It.IsAny<IEnumerable<ScoreDetailsDto>>()));

            ScoreDetailsController scoreController = new ScoreDetailsController(mockSourceTrackerRepo.Object, new NullLogger<ScoreDetailsController>(), mockMapper.Object);
            var result = (OkObjectResult)scoreController.UpdateScoreforPlayer("Joe",1);
            Assert.AreEqual(200, result.StatusCode); ;

        }


        [TestMethod]
        public void UpdatePlayerScoresPositiveValueReturnsNotFoundStatusCode()
        {

            #region expectedData
            ICollection<ScoreDetails> playerScoreList = new List<ScoreDetails>();
            ScoreDetails scoreDetails1 = new ScoreDetails();
            scoreDetails1.Player = "Joe";
            scoreDetails1.Score = 2;
            ScoreDetails scoreDetails2 = new ScoreDetails();
            scoreDetails2.Player = "Jane";
            scoreDetails2.Score = 1;
            ScoreDetails scoreDetails3 = new ScoreDetails();
            scoreDetails3.Player = "Jonny";
            scoreDetails3.Score = 5;
            ScoreDetails scoreDetails4 = new ScoreDetails();
            scoreDetails4.Player = "Jeremy";
            scoreDetails4.Score = 2;

            playerScoreList.Add(scoreDetails1);
            playerScoreList.Add(scoreDetails2);
            playerScoreList.Add(scoreDetails3);
            playerScoreList.Add(scoreDetails4);
            #endregion
            Mock<IScoreTrackerRepo> mockSourceTrackerRepo = new Mock<IScoreTrackerRepo>();
            mockSourceTrackerRepo.Setup(s => s.UpdateScoreForPlayer(It.IsAny<string>(), It.IsAny<int>()));

            Mock<IMapper> mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<IEnumerable<ScoreDetailsDto>>(It.IsAny<IEnumerable<ScoreDetailsDto>>()));

            ScoreDetailsController scoreController = new ScoreDetailsController(mockSourceTrackerRepo.Object, new NullLogger<ScoreDetailsController>(), mockMapper.Object);
            var result = (NotFoundResult)scoreController.UpdateScoreforPlayer("Joseph", 1);
            Assert.AreEqual(404, result.StatusCode); ;

        }





    }
}
