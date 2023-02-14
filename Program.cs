using Characters;
using Figgle;
using Utils;

namespace IPI_INET400_CSharp_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var pr = new Program();
            
            Console.WriteLine(FiggleFonts.Ogre.Render("Console Battle"));
            Console.WriteLine("Veuillez sélectionner un mode de jeu...");
            Console.WriteLine("Duel(tapez d) | Battle Royal (tapez b)");
            string mode = new string(Console.ReadLine());

            if (mode == "d")
            {
                Console.WriteLine("========== DUEL ==========");

                Character robot = new Robot();
                Character kamikaze = new Kamikaze();

                var jetAttackRobot = robot.JetAttack();
                var jetDefenseRobot = robot.JetDefense();
                var jetAttackKamikaze = kamikaze.JetAttack();
                var jetDefenseKamikaze = kamikaze.JetDefense();

                Console.WriteLine("Jet d'intiative " + robot.GetType().Name + " : " + + robot.Attack + " + " + (jetAttackRobot - robot.Attack) + " = " + jetAttackRobot);
                Console.WriteLine("Jet d'intiative " + kamikaze.GetType().Name + " : " + kamikaze.Attack + " + " + (jetAttackKamikaze - kamikaze.Attack) + " = " + jetAttackKamikaze + "\n");
            
                if (jetAttackRobot > jetAttackKamikaze)
                {
                    Console.WriteLine("Robot attaque Kamikaze!");
                    pr.margeAttack(jetAttackRobot - jetDefenseKamikaze, jetAttackRobot, kamikaze);
                }
                else if (jetAttackRobot < jetAttackKamikaze)
                {
                    Console.WriteLine("Kamikaze attaque Robot!");
                    pr.margeAttack(jetAttackKamikaze - jetDefenseRobot, jetAttackKamikaze, robot);
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
        
        private void margeAttack(int marge, int jetChAttacking, Character chAttacked)
        {
            if (marge > 0)
            {
                chAttacked.CurrentLife -= marge * jetChAttacking / 100;
                Console.WriteLine("💥Marge d'attaque: " + marge);
                Console.WriteLine("🩸Dégats subis par " + chAttacked.GetType().Name + ": " + marge * jetChAttacking / 100);
                getStats(chAttacked);
            }
            else
            {
                
            }
        }

        private void getStats(Character character)
        {
            Console.WriteLine("📊Stats " + character.GetType().Name + " :");
            Console.WriteLine("🫀" + character.CurrentLife);
        }
    }
}
