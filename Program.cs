using Characters;
using Utils;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Instanciate two list of characters
            var TeamA = new List<Character>() { new Berserker(), new Vampire(), new Zombie(), new Gardien(), new Guerrier() };
            var TeamB = new List<Character>() { new Goule(), new Kamikaze(), new Liche(), new Pretre(), new Robot() };
            var CopyTeamA = new List<Character>();
            
            // Make initiave Jet
            var JetInitiativeA = TeamA[UtilsCharacters.getRandomIndex(TeamA)].Jet();
            var JetInitiativeB = TeamB[UtilsCharacters.getRandomIndex(TeamB)].Jet();
            
            if(JetInitiativeA > JetInitiativeB) {
                CopyTeamA = TeamA;
                TeamA = TeamB;
                TeamB = CopyTeamA;
            }
            
            var round = 0;
            do
            {
                // Team A attack
                foreach (var character in TeamA)
                {
                    // TeamA attack random character in teamB
                    var randomIndex = UtilsCharacters.getRandomIndex(TeamA);
                    character.AttackCharacter(TeamB[randomIndex]);
                }

                // Team B attack
                foreach (var character in TeamB)
                {
                    // TeamB attack random character in TeamB
                    var randomIndex = UtilsCharacters.getRandomIndex(TeamB);
                    character.AttackCharacter(TeamA[randomIndex]);
                }
                round++;
            } while(UtilsCharacters.checkSomebodyAlive(TeamA) || UtilsCharacters.checkSomebodyAlive(TeamB));


            if (UtilsCharacters.checkSomebodyAlive(TeamA))
            {
                Console.WriteLine("Team A win");
            }
            else
            {
                Console.WriteLine("Team B win");
            }
            
        }
    }
}
