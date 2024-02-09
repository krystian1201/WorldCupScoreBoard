
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

        private uint _homeTeamGoals;
        internal uint HomeTeamGoals
        {
            get { return _homeTeamGoals; }
        }
        
        private uint _awayTeamGoals;
        internal uint AwayTeamGoals
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

        internal void UpdateScore(uint homeTeamGoals, uint awayTeamGoals)
        {
            _homeTeamGoals = homeTeamGoals;
            _awayTeamGoals = awayTeamGoals;
        }

        internal uint GetTotalScore()
        {
            return _homeTeamGoals + _awayTeamGoals;
        }
    }
}
