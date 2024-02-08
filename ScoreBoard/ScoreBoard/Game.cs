
namespace WorldCupScoreBoard
{
    internal class Game
    {
        private string _homeTeamName;
        public string HomeTeamName  
        {
            get { return _homeTeamName; }    
        } 

        private string _awayTeamName;
        public string AwayTeamName
        {
            get { return _awayTeamName; }
        }

        private int _homeTeamGoals;
        public int HomeTeamGoals
        {
            get { return _homeTeamGoals; }
        }
        
        private int _awayTeamGoals;
        public int AwayTeamGoals
        {
            get { return _awayTeamGoals; }
        }

        public Game(string homeTeam, string awayTeam)
        {
            _homeTeamName  = homeTeam;
            _awayTeamName = awayTeam;
            _homeTeamGoals = 0;
            _awayTeamGoals = 0;
        }

        public void UpdateHomeTeamGoals(int goals)
        {
            _homeTeamGoals = goals;
        }

        public void UpdateAwayTeamGoals(int goals)
        {
            _awayTeamGoals = goals;
        }
    }
}
