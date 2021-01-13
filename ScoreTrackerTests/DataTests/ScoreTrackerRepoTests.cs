using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ScoreTracker.Data;
using ScoreTracker.Models;
using ScoreTracker.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreTrackerTests.DataTests
{
    [TestClass]
    public class ScoreTrackerRepoTests
    {
        #region ReadTests

        private const string jsonTestData="[\r\n  {\r\n    \"Player\": \"Joe\",\r\n    \"Score\": 4\r\n  },\r\n  {\r\n    \"Player\": \"Jane\",\r\n    \"Score\": 1\r\n  },\r\n  {\r\n    \"Player\": \"Jonny\",\r\n    \"Score\": 5\r\n  },\r\n  {\r\n    \"Player\": \"Jeremy\",\r\n    \"Score\": 2\r\n  }\r\n]";
        [TestMethod]
        public void GetNumberOfScoresforPositiveValueReturnsInteger()
        {
            Mock<IFileOperations> mockFileOperations = new Mock<IFileOperations>();
            mockFileOperations.Setup(f => f.ReadDataFromFileDatabase()).Returns(jsonTestData);
            ScoreTrackerRepo scoreTrackerRepo = new ScoreTrackerRepo(mockFileOperations.Object);
            var result=scoreTrackerRepo.GetNumberOfScoresAboveThreshold(1);
            Assert.AreEqual(3, result);

        }


        [TestMethod]
        public void GetNumberOfScoresforNegativeValueReturnsInteger()
        {
            Mock<IFileOperations> mockFileOperations = new Mock<IFileOperations>();
            mockFileOperations.Setup(f => f.ReadDataFromFileDatabase()).Returns(jsonTestData);
            ScoreTrackerRepo scoreTrackerRepo = new ScoreTrackerRepo(mockFileOperations.Object);
            var result = scoreTrackerRepo.GetNumberOfScoresAboveThreshold(-1);
            Assert.AreEqual(4, result);

        }

        #endregion

        #region UpdateTests
        [TestMethod]
        public void UpdateScoreForPlayerValidPlayerAndScoreReturnsValidNonZeroItems()
        {

            #region expectedData
            List<ScoreDetails> playerScoreList = new List<ScoreDetails>();
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


            Mock<IFileOperations> mockFileOperations = new Mock<IFileOperations>();
            mockFileOperations.Setup(f => f.ReadDataFromFileDatabase()).Returns(jsonTestData);
            mockFileOperations.Setup(f => f.WriteDataToFileDatabase(It.IsAny<string>())).Returns(true);
            ScoreTrackerRepo scoreTrackerRepo = new ScoreTrackerRepo(mockFileOperations.Object);
            var result=scoreTrackerRepo.UpdateScoreForPlayer("Joe", 2);
            var resultList = (List<ScoreDetails>)result;
            Assert.IsTrue(resultList.Count > 0);
            Assert.AreEqual(playerScoreList[0].Player, resultList[0].Player);
            Assert.AreEqual(playerScoreList[0].Player, resultList[0].Player);
        }



        [TestMethod]
        public void UpdateScoreForPlayerVerifyValuesReturnedReturnsValidItems()
        {
            //Arrange
            #region expectedData
            List<ScoreDetails> playerScoreList = new List<ScoreDetails>();
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


            Mock<IFileOperations> mockFileOperations = new Mock<IFileOperations>();
            mockFileOperations.Setup(f => f.ReadDataFromFileDatabase()).Returns(jsonTestData);
            mockFileOperations.Setup(f => f.WriteDataToFileDatabase(It.IsAny<string>())).Returns(true);

            //Act
            ScoreTrackerRepo scoreTrackerRepo = new ScoreTrackerRepo(mockFileOperations.Object);
            var result = scoreTrackerRepo.UpdateScoreForPlayer("Joe", 2);
            var resultList = (List<ScoreDetails>)result;
         

            //Assert
            //check players data - asserts can be split to different unit test cases if needed 
            Assert.AreEqual(playerScoreList[0].Player, resultList[0].Player);
            Assert.AreEqual(playerScoreList[1].Player, resultList[1].Player);
            Assert.AreEqual(playerScoreList[2].Player, resultList[2].Player);
            Assert.AreEqual(playerScoreList[3].Player, resultList[3].Player);

            //check score data - asserts can be split to different unit test cases if needed 
            Assert.AreEqual(playerScoreList[0].Score, resultList[0].Score);
            Assert.AreEqual(playerScoreList[1].Score, resultList[1].Score);
            Assert.AreEqual(playerScoreList[2].Score, resultList[2].Score);
            Assert.AreEqual(playerScoreList[3].Score, resultList[3].Score);
        }



        [TestMethod]
        public void UpdateScoreForPlayerInValidPlayerInputReturnsZeroSourceDetailsObjects()
        {
            //Arrange
            #region expectedData
            List<ScoreDetails> playerScoreList = new List<ScoreDetails>();
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


            Mock<IFileOperations> mockFileOperations = new Mock<IFileOperations>();
            mockFileOperations.Setup(f => f.ReadDataFromFileDatabase()).Returns(jsonTestData);
            mockFileOperations.Setup(f => f.WriteDataToFileDatabase(It.IsAny<string>())).Returns(true);

            //Act
            ScoreTrackerRepo scoreTrackerRepo = new ScoreTrackerRepo(mockFileOperations.Object);
            var result = scoreTrackerRepo.UpdateScoreForPlayer("Joseph", 2);
            var resultList = (List<ScoreDetails>)result;


            //Assert
            Assert.IsTrue(resultList.Count==0);
        }
        #endregion
    }
}
