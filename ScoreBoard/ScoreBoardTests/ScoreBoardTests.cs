
namespace WorldCupScoreBoard.UnitTests
{
    [TestFixture]
    public class ScoreBoardTests
    {
        private ScoreBoard _scoreBoard;

        [SetUp]
        public void SetUp()
        {
            _scoreBoard = new ScoreBoard();
        }

        [Test]
        public void StartNewGame_ResultsInInitialScore_0_0()
        {
            //Arrange
            _scoreBoard.StartNewGame("Mexico", "Canada");

            //Act
            string scoreBoardSummary = _scoreBoard.GetSummary();

            //Assert
            Assert.That(scoreBoardSummary, Is.EqualTo("1. Mexico 0 - Canada 0"));
        }

        [Test]
        public void UpdateScore_UpdatesScore_IfTheSpecifiedGameIsInProgress()
        {
            //Arrange
            _scoreBoard.StartNewGame("Spain", "Brazil");

            //Act
            _scoreBoard.UpdateScoreForGame("Spain", "Brazil", 10, 2);
            string scoreBoardSummary = _scoreBoard.GetSummary();

            //Assert
            Assert.That(scoreBoardSummary, Is.EqualTo("1. Spain 10 - Brazil 2"));
        }

        [Test]
        public void UpdateScore_ThrowsException_IfThereIsNoGameBetweenSpecifiedTeams()
        {
            //Arrange
            _scoreBoard.StartNewGame("Mexico", "Canada");

            //Act, Assert
            Assert.Throws<InvalidOperationException>(() => _scoreBoard.UpdateScoreForGame("Spain", "Brazil", 10, 2));
        }

        [Test]
        public void UpdateScore_ThrowsException_IfThereAreNoGamesAtAll()
        {
            //Act, Assert
            Assert.Throws<InvalidOperationException>(() => _scoreBoard.UpdateScoreForGame("Spain", "Brazil", 10, 2));
        }

        [Test]
        public void FinishGame_RemovesGameFromScoreBoard_IfTheSpecifiedGameIsInProgress()
        {
            //Arrange
            _scoreBoard.StartNewGame("Mexico", "Canada");

            //Act
            string scoreBoardSummary = _scoreBoard.GetSummary();

            //Assert
            Assert.That(scoreBoardSummary, Is.EqualTo("1. Mexico 0 - Canada 0"));

            //Act
            _scoreBoard.FinishGame("Mexico", "Canada");

            //Assert
            Assert.That(scoreBoardSummary, Is.EqualTo(string.Empty));
        }
    }
}
