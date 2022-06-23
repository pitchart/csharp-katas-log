namespace Tennis
{
    
    //TODO:
    // - Rationnaliser le lien entre le score et le joueur (DataClumps)
    // - Multiple responsabilités de score dans la méthode GetScore qui renvoie et le score actuel et le résultat du jeu
    // - Refactoriser le switch des égalités
    // - Expliciter et faire ressortir des méthodes pour les cas des avantages et du jeu courant
    class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            string score = "";

            var isScoreEquality = m_score1 == m_score2;
            
            if (isScoreEquality)
            {
                score = HandleEqualityCase();
            }
            else
            {
                
                if (IsAdvantage())
                {
                    score = GetAdvantageOrWinScore();
                }
                //Jeu courant (inégalité)
                else
                {
                    score = $"{(ScoreLabel)m_score1}-{(ScoreLabel)m_score2}";
                }
            }

            return score;
        }

        private bool IsAdvantage()
        {
            return m_score1 >= 4 || m_score2 >= 4;
        }

        private string GetAdvantageOrWinScore()
        {
            string score;
            var minusResult = m_score1 - m_score2;
            score = minusResult switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2"
            };

            return score;
        }

        private string HandleEqualityCase()
        {
            return m_score1 switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
        }
    }
}

