
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
        public void StartNewGame_ReturnsInitialScore_0_0()
        {
            //Arrange
            _scoreBoard.StartNewGame("Mexico", "Canada");

            //Act
            string scoreBoardSummary = _scoreBoard.GetSummary();

            //Assert
            Assert.That(scoreBoardSummary, Is.EqualTo("1. Mexico 0 - Canada 0"));
        }

        [Test]
        public void UpdateScore_UpdatesScore()
        {
            //Arrange
            _scoreBoard.StartNewGame("Spain", "Brazil");

            //Act
            _scoreBoard.UpdateScore("Spain", "Brazil", 10, 2);
            string scoreBoardSummary = _scoreBoard.GetSummary();

            //Assert
            Assert.That(scoreBoardSummary, Is.EqualTo("1. Spain 10 - Brazil 2"));
        }
    }
}
