using System.Text;

namespace WorldCupScoreBoard
{
    public class ScoreBoard
    {
        private List<Game> _gamesInProgress = new List<Game>();

        public void StartNewGame(string homeTeamName, string awayTeamName)
        {
            _gamesInProgress.Add(new Game(homeTeamName, awayTeamName));
        }

        public void UpdateScoreForGame(string homeTeamName, string awayTeamName, uint homeTeamGoals, uint awayTeamGoals) 
        {
            try
            {
                var game = _gamesInProgress.First(g => g.HomeTeamName == homeTeamName && g.AwayTeamName == awayTeamName);

                game.UpdateScore(homeTeamGoals, awayTeamGoals);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException($"Cannot update score. There is no ongoing game between specified teams.");
            }
        }

        public string GetSummaryOfGames()
        {
            var sb = new StringBuilder();

            _gamesInProgress.Reverse();

            var gamesOrdered = _gamesInProgress.OrderByDescending(g => g.GetTotalScore()).ToList();

            for (int i = 0; i < gamesOrdered.Count; i++)
            {
                var game = gamesOrdered[i];

                if (i < _gamesInProgress.Count - 1)
                {
                    sb.AppendLine($"{i + 1}. {game.HomeTeamName} {game.HomeTeamGoals} - {game.AwayTeamName} {game.AwayTeamGoals}");
                }
                else
                {
                    sb.Append($"{i + 1}. {game.HomeTeamName} {game.HomeTeamGoals} - {game.AwayTeamName} {game.AwayTeamGoals}");
                }   
            }

            return sb.ToString();
        }

        public void FinishGame(string homeTeamName, string awayTeamName)
        {
            try
            {
                var game = _gamesInProgress.First(g => g.HomeTeamName == homeTeamName && g.AwayTeamName == awayTeamName);

                _gamesInProgress.Remove(game);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException($"Cannot finish game. There is no ongoing game between specified teams.");
            }  
        }
    }
}
