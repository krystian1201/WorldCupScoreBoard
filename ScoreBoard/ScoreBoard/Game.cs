
namespace WorldCupScoreBoard
{
    internal class Game
    {
        private string _homeTeamName;
        internal string HomeTeamName  
        {
            get { return _homeTeamName; }    
        } 

        private string _awayTeamName;
        internal string AwayTeamName
        {
            get { return _awayTeamName; }
        }

        private int _homeTeamGoals;
        internal int HomeTeamGoals
        {
            get { return _homeTeamGoals; }
        }
        
        private int _awayTeamGoals;
        internal int AwayTeamGoals
        {
            get { return _awayTeamGoals; }
        }

        internal Game(string homeTeam, string awayTeam)
        {
            _homeTeamName  = homeTeam;
            _awayTeamName = awayTeam;
            _homeTeamGoals = 0;
            _awayTeamGoals = 0;
        }

        internal void UpdateScore(int homeTeamGoals, int awayTeamGoals)
        {
            _homeTeamGoals = homeTeamGoals;
            _awayTeamGoals = awayTeamGoals;
        }

        internal int GetTotalScore()
        {
            return _homeTeamGoals + _awayTeamGoals;
        }
    }
}
