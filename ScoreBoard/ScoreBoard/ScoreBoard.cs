using System.Text;

namespace WorldCupScoreBoard
{
    public class ScoreBoard
    {
        private List<Game> _scoreBoardGames = new List<Game>();

        public void StartNewGame(string homeTeamName, string awayTeamName)
        {
            _scoreBoardGames.Add(new Game(homeTeamName, awayTeamName));
        }

        public string GetSummary()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < _scoreBoardGames.Count; i++)
            {
                var game = _scoreBoardGames[i];

                if (i < _scoreBoardGames.Count - 1)
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
    }
}
