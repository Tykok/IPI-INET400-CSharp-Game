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

                var robot = new Robot();
                var kamikaze = new Kamikaze();

                var i = 1;
                while (!robot.IsDead() && !kamikaze.IsDead())
                {
                    Console.WriteLine("********* ROUND " + i + " *********");
                    robot.StartRound();
                    kamikaze.StartRound();
                    var jetInitiativeRobot = robot.JetAttack();
                    var jetInitiativeKamikaze = kamikaze.JetAttack();
                    if (robot.TotalAttackNumber > 0 || kamikaze.TotalAttackNumber > 0)
                    {
                        Console.WriteLine("Jet d'intiative " + robot.GetType().Name + " : " + robot.Attack + " + " +
                                          (robot.JetAttack() - robot.Attack) + " = " + jetInitiativeRobot);
                        Console.WriteLine("Jet d'intiative " + kamikaze.GetType().Name + " : " + kamikaze.Attack +
                                          " + " + (kamikaze.JetAttack() - kamikaze.Attack) + " = " +
                                          jetInitiativeKamikaze + "\n");

                        if (jetInitiativeRobot > jetInitiativeKamikaze)
                        {
                            Console.WriteLine(robot.GetType().Name + " attaque " + kamikaze.GetType().Name + "." +
                                              "\n");
                            robot.AttackSomeone(kamikaze);
                        }
                        else
                        {
                            Console.WriteLine(kamikaze.GetType().Name + " attaque " + robot.GetType().Name + "." +
                                              "\n");
                            kamikaze.AttackSomeone(robot);
                        }
                        
                        
                        Console.WriteLine("🫀Robot: " + (robot.CurrentLife >= 0 ? robot.CurrentLife : 0));
                        Console.WriteLine("🫀Kamikaze: " + (kamikaze.CurrentLife >= 0 ? kamikaze.CurrentLife : 0));
                    }

                    i++;
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

        private void getStats(Character character)
        {
            Console.WriteLine("📊Stats " + character.GetType().Name + " :");
            Console.WriteLine("🫀" + (character.CurrentLife >= 0 ? character.CurrentLife : 0));
        }
    }
}
