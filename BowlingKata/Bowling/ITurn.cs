using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    //Todo : Make an interface to handle bonus turn
    public interface ITurn
    {

        public int GetTotalScore();

        public void Roll(int fallenPins);

        //TODO: méthodes privées qui ne devraient pas être là
        public int GetTotalScoreRec(int currentScore);
        public int GetFirstRollScore();

        public int GetStrikeBonus();

    }
}
