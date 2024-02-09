
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
        public void GetSummary_ReturnsEmptyString_IfThereAreNoGames()
        {
            //Act
            string scoreBoardSummary = _scoreBoard.GetSummaryOfGames();

            //Assert
            Assert.That(scoreBoardSummary, Is.EqualTo(string.Empty));
        }

        [Test]
        public void StartNewGame_ResultsInInitialScore_0_0()
        {
            //Arrange
            _scoreBoard.StartNewGame("Mexico", "Canada");

            //Act
            string scoreBoardSummary = _scoreBoard.GetSummaryOfGames();

            //Assert
            Assert.That(scoreBoardSummary, Is.EqualTo("1. Mexico 0 - Canada 0"));
        }

        [Test]
        public void StartNewGame_ThrowsException_IfTheGameBetweenAnyGivenTeamIsInProgress()
        {
            //Arrange
            _scoreBoard.StartNewGame("Mexico", "Canada");

            //Act, Assert
            var ex = Assert.Throws<InvalidOperationException>(() => _scoreBoard.StartNewGame("Mexico", "Canada"));
            Assert.That(ex.Message, Is.EqualTo("Cannot start a game. At least one of the specified teams have already a game in progress."));

            ex = Assert.Throws<InvalidOperationException>(() => _scoreBoard.StartNewGame("Mexico", "Spain"));
            Assert.That(ex.Message, Is.EqualTo("Cannot start a game. At least one of the specified teams have already a game in progress."));

            ex = Assert.Throws<InvalidOperationException>(() => _scoreBoard.StartNewGame("Spain", "Canada"));
            Assert.That(ex.Message, Is.EqualTo("Cannot start a game. At least one of the specified teams have already a game in progress."));

            ex = Assert.Throws<InvalidOperationException>(() => _scoreBoard.StartNewGame("Canada", "Mexico"));
            Assert.That(ex.Message, Is.EqualTo("Cannot start a game. At least one of the specified teams have already a game in progress."));

            ex = Assert.Throws<InvalidOperationException>(() => _scoreBoard.StartNewGame("Spain", "Mexico"));
            Assert.That(ex.Message, Is.EqualTo("Cannot start a game. At least one of the specified teams have already a game in progress."));

            ex = Assert.Throws<InvalidOperationException>(() => _scoreBoard.StartNewGame("Canada", "Spain"));
            Assert.That(ex.Message, Is.EqualTo("Cannot start a game. At least one of the specified teams have already a game in progress."));
        }

        [Test]
        public void UpdateScore_UpdatesScore_IfTheSpecifiedGameIsInProgress()
        {
            //Arrange
            _scoreBoard.StartNewGame("Spain", "Brazil");

            //Act
            _scoreBoard.UpdateScoreForGame("Spain", "Brazil", 10, 2);
            string scoreBoardSummary = _scoreBoard.GetSummaryOfGames();

            //Assert
            Assert.That(scoreBoardSummary, Is.EqualTo("1. Spain 10 - Brazil 2"));
        }

        [Test]
        public void UpdateScore_ThrowsException_IfThereIsNoGameBetweenSpecifiedTeams()
        {
            //Arrange
            _scoreBoard.StartNewGame("Mexico", "Canada");

            //Act, Assert
            var ex = Assert.Throws<InvalidOperationException>(() => _scoreBoard.UpdateScoreForGame("Spain", "Brazil", 10, 2));

            Assert.That(ex.Message, Is.EqualTo("Cannot update score. There is no ongoing game between specified teams."));
        }

        [Test]
        public void UpdateScore_ThrowsException_IfThereAreNoGamesAtAll()
        {
            //Act, Assert
            var ex = Assert.Throws<InvalidOperationException>(() => _scoreBoard.UpdateScoreForGame("Spain", "Brazil", 10, 2));

            Assert.That(ex.Message, Is.EqualTo("Cannot update score. There is no ongoing game between specified teams."));
        }

        [Test]
        public void FinishGame_RemovesGameFromScoreBoard_IfTheSpecifiedGameIsInProgress()
        {
            //Arrange
            _scoreBoard.StartNewGame("Mexico", "Canada");

            //Act
            string scoreBoardSummary = _scoreBoard.GetSummaryOfGames();

            //Assert
            Assert.That(scoreBoardSummary, Is.EqualTo("1. Mexico 0 - Canada 0"));

            //Arrange
            _scoreBoard.FinishGame("Mexico", "Canada");

            //Act
            scoreBoardSummary = _scoreBoard.GetSummaryOfGames();

            //Assert
            Assert.That(scoreBoardSummary, Is.EqualTo(string.Empty));
        }

        [Test]
        public void FinishGame_ShouldBeAbleToRemoveGameNotNecesarilyInTheOrderItWasStarted()
        {
            //Arrange
            _scoreBoard.StartNewGame("Mexico", "Canada");
            _scoreBoard.StartNewGame("Spain", "Brazil");
            _scoreBoard.StartNewGame("Germany", "France");


            //Act
            string scoreBoardSummary = _scoreBoard.GetSummaryOfGames();

            //Assert
            Assert.That(scoreBoardSummary, Is.EqualTo("1. Germany 0 - France 0\r\n2. Spain 0 - Brazil 0\r\n3. Mexico 0 - Canada 0"));

            //Act
            _scoreBoard.FinishGame("Spain", "Brazil");
            scoreBoardSummary = _scoreBoard.GetSummaryOfGames();

            //Assert
            Assert.That(scoreBoardSummary, Is.EqualTo("1. Germany 0 - France 0\r\n2. Mexico 0 - Canada 0"));
        }

        [Test]
        public void FinishGame_ThrowsException_IfThereIsNoGameBetweenSpecifiedTeams()
        {
            //Arrange
            _scoreBoard.StartNewGame("Mexico", "Canada");

            //Act, Assert
            var ex = Assert.Throws<InvalidOperationException>(() => _scoreBoard.FinishGame("Spain", "Brazil"));

            Assert.That(ex.Message, Is.EqualTo("Cannot finish game. There is no ongoing game between specified teams."));
        }

        [Test]
        public void GetSummary_ReturnsGamesInProgressOrderedByTheirTotalScore()
        {
            //Arrange
            _scoreBoard.StartNewGame("Mexico", "Canada");
            _scoreBoard.StartNewGame("Spain", "Brazil");
            _scoreBoard.StartNewGame("Germany", "France");

            _scoreBoard.UpdateScoreForGame("Mexico", "Canada", 0, 5);
            _scoreBoard.UpdateScoreForGame("Spain", "Brazil", 10, 2);
            _scoreBoard.UpdateScoreForGame("Germany", "France", 2, 2);

            //Act
            string scoreBoardSummary = _scoreBoard.GetSummaryOfGames();

            //Assert
            Assert.That(scoreBoardSummary, Is.EqualTo("1. Spain 10 - Brazil 2\r\n2. Mexico 0 - Canada 5\r\n3. Germany 2 - France 2"));
        }

        [Test]
        public void GetSummary_ReturnsGamesInProgressOrderedByTheirTotalScoreAndOrderOfStarting()
        {
            //Arrange
            _scoreBoard.StartNewGame("Mexico", "Canada");
            _scoreBoard.StartNewGame("Spain", "Brazil");
            _scoreBoard.StartNewGame("Germany", "France");
            _scoreBoard.StartNewGame("Uruguay", "Italy");

            _scoreBoard.UpdateScoreForGame("Mexico", "Canada", 0, 5);
            _scoreBoard.UpdateScoreForGame("Spain", "Brazil", 10, 2);
            _scoreBoard.UpdateScoreForGame("Germany", "France", 2, 2);
            _scoreBoard.UpdateScoreForGame("Uruguay", "Italy", 6, 6);

            //Act
            string scoreBoardSummary = _scoreBoard.GetSummaryOfGames();

            //Assert
            Assert.That(scoreBoardSummary, Is.EqualTo("1. Uruguay 6 - Italy 6\r\n2. Spain 10 - Brazil 2\r\n3. Mexico 0 - Canada 5\r\n4. Germany 2 - France 2"));
        }
    }
}
