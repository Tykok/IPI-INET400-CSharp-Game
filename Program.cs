using Characters;
using Function;

namespace IPI_INET400_CSharp_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of characters
            var numberOfFighters = ConsoleInterraction.GetNumberOfFighters();
            List<Character> listOfCharacter = UtilsCharacters.GetAListOfRandomCharacter(numberOfFighters);
            List<Character> listOfLosingCharacter = new List<Character>();
            var round = 1;

            // While until only one character is alive
            do
            {
                Console.WriteLine("***************************************");
                Console.WriteLine("*************** ROUND " + round + " ***************");
                Console.WriteLine("***************************************");
                listOfCharacter = listOfCharacter.OrderBy(x => x.JetInitiative()).ToList();
                for (int i = 0; i < listOfCharacter.Count; i++)
                {
                    var character = listOfCharacter[i];
                    
                    if (character.CurrentLife <= 0)
                    {
                        listOfLosingCharacter.Add(character);
                        listOfCharacter.Remove(character);
                        continue;
                    }
                    
                    character.StartRound();
                    character.AttackSomeone(listOfCharacter);
                    
                    Console.WriteLine("👤" + character.GetType().Name + " :");
                    character.StartRound();
                    character.AttackSomeone(listOfCharacter);
                }

                round++;
            } while(listOfCharacter.Count > 1);
        }

        private void getStats(Character character)
        {
            Console.WriteLine("📊Stats " + character.GetType().Name + " :");
            Console.WriteLine("🫀" + character.CurrentLife);
        }
    }
}
