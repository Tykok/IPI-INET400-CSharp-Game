using Characters;
using Figgle;
using Utils;

namespace IPI_INET400_CSharp_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FiggleFonts.Ogre.Render("Console Battle"));
            Console.WriteLine("Veuillez sélectionner un mode de jeu...");
            Console.WriteLine("Duel(tapez d) | Battle Royal (tapez b)");
            string mode = new string(Console.ReadLine());

            if (mode == "d")
            {
                Console.WriteLine("========== DUEL ==========");

                Character walle = new Robot();
                Character momo = new Kamikaze();

                var jetWalle = walle.JetAttack();
                var jetMomo = momo.JetAttack();

                Console.WriteLine("Jet d'intiative Wall-E: " + walle.Attack + " + " + (jetWalle - walle.Attack) + " = " + jetWalle);
                Console.WriteLine("Jet d'intiative Momo: " + momo.Attack + " + " + (jetMomo - momo.Attack) + " = " + jetMomo);
                Console.WriteLine("Marge d'attaque: " + (walle.Attack + jetWalle) + " - " + (momo.Attack + jetMomo) +
                                  " = " + ((walle.Attack + jetWalle) - (momo.Attack + jetMomo)));

                if (walle.Attack + jetWalle > momo.Attack + jetMomo)
                {
                    Console.WriteLine("Walle attaque Momo!");
                    
                }
                
            }
            else if (mode == "b")
            {
                Console.WriteLine("========== BATTLE ROYAL ==========");
                // Instanciate two list of characters
                List<Character> TeamA = new List<Character>()
                {
                    new Berserker(),
                    new Vampire(),
                    new Zombie(),
                    new Gardien(),
                    new Guerrier()
                };
                List<Character> TeamB = new List<Character>()
                {
                    new Goule(),
                    new Kamikaze(),
                    new Liche(),
                    new Pretre(),
                    new Robot()
                };
                List<Character> CopyTeamA = new List<Character>();

                // Make initiave Jet
                var JetInitiativeA = TeamA[UtilsCharacters.getRandomIndex(TeamA)].JetAttack();
                var JetInitiativeB = TeamB[UtilsCharacters.getRandomIndex(TeamB)].JetAttack();

                if (JetInitiativeA > JetInitiativeB)
                {
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
                } while (UtilsCharacters.checkSomebodyAlive(TeamA) || UtilsCharacters.checkSomebodyAlive(TeamB));


                if (UtilsCharacters.checkSomebodyAlive(TeamA))
                {
                    Console.WriteLine("Team A win");
                }
                else
                {
                    Console.WriteLine("Team B win");
                }
            }
            else
            {
                Console.WriteLine("Fin");
            }
        }
    }
}
