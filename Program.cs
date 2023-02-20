using Characters;
using Function;

namespace IPI_INET400_CSharp_Game;
class Program
    {
        static void Main(string[] args)
        {
            // Create a list of characters
            var numberOfFighters = ConsoleInterraction.GetNumberOfFighters();
            List<Character> listOfCharacter = UtilsCharacters.GetAListOfRandomCharacter(numberOfFighters);
            List<Character> listOfLosingCharacter = new List<Character>() {};
            var round = 1;

            // While until only one character is alive
            do
            {
                Console.WriteLine("\n***************************************");
                Console.WriteLine("*************** ROUND " + round + " ***************");
                Console.WriteLine("***************************************\n");
                
                // Sort the list of character by initiative
                listOfCharacter = listOfCharacter.OrderByDescending(x => x.JetInitiative()).ToList();
                
                // Start round for all character
                listOfCharacter.ForEach(x => x.StartRound());
                
                do {
                    
                    if (UtilsCharacters.CheckIfSomebodyDie(listOfCharacter))
                    {
                        var allDeadCharacter = listOfCharacter.FindAll(x=> x.IsDead());
                        allDeadCharacter.ForEach(x => listOfLosingCharacter.Add(x));
                        listOfCharacter.RemoveAll(x => x.IsDead());
                        ConsoleInterraction.ShowAllDeadCharacter(allDeadCharacter);
                        UtilsCharacters.CharognardEatDeadBody(allDeadCharacter, listOfCharacter);
                        continue;
                    }
                    
                    // Find the first character who can attack
                    var character = listOfCharacter.Find(x => x.CurrentAttackNumber > 0);
                    character.AttackSomeone(listOfCharacter);
                }
                while (UtilsCharacters.SomebodyCanAttack(listOfCharacter) && listOfCharacter.Count > 1) ;

                Console.WriteLine("\nRésumé du round");
                ConsoleInterraction.ResumeOfAllCharacter(listOfCharacter);
                Console.WriteLine("Press any key to continue to the next round");
                Console.ReadKey();
                round++;
            } while(listOfCharacter.Count > 1);

            ConsoleInterraction.ShowLosingClassement(listOfLosingCharacter);
            Console.WriteLine("The winner is : " + listOfCharacter[0].GetType().Name);
        }
    }
