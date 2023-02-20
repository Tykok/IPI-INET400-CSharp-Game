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
                listOfCharacter = listOfCharacter.OrderByDescending(x => x.JetInitiative()).ToList();
                
                // Start round for all character
                listOfCharacter.ForEach(x => x.StartRound());
                
                for (int i = 0; i < listOfCharacter.Count; i++)
                {
                    var character = listOfCharacter[i];
                    
                    if (UtilsCharacters.CheckIfSomebodyDie(listOfCharacter))
                    {
                        var allDeadCharacter = listOfCharacter.FindAll(x=> x.IsDead());
                        allDeadCharacter.ForEach(x => listOfLosingCharacter.Add(x));
                        listOfCharacter.RemoveAll(x => x.IsDead());
                        ConsoleInterraction.ShowAllDeadCharacter(allDeadCharacter);
                        continue;
                    }
                    
                    character.AttackSomeone(listOfCharacter);
                }

                Console.WriteLine("\nRésumé du round");
                ConsoleInterraction.ResumeOfAllCharacter(listOfCharacter);
                round++;
            } while(listOfCharacter.Count > 1);

            ConsoleInterraction.ShowLosingClassement(listOfLosingCharacter);
            Console.WriteLine("The winner is : " + listOfCharacter[0].GetType().Name);
        }
    }
