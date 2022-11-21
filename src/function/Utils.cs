namespace Utils;
using Characters;

public static class Utils
{

    /// <summary>Contains the list of available Characters</summary>
    public static readonly Dictionary<string, Character> LIST_OF_CHARACTERS = new Dictionary<string, Character>()
    {
        {"Guerrier",new Guerrier(100, 100, 50, 100, 200, 200, 2, 2)},
        {"Gardien", new Gardien(50, 150, 50, 50, 150, 150, 3, 3)},
        {"Berserker", new Berserker(100, 100, 80, 20, 300, 300, 1, 1)},
        {"Zombie", new Zombie(100, 0, 20, 60, 1000, 1000, 1, 1)},
        {"Robot", new Robot(10, 100, 50, 50, 200, 200, 1, 1)},
        {"Liche", new Liche(75, 125, 80, 50, 125, 125, 3, 3)},
        {"Goule", new Goule(50, 80, 120, 30, 250, 250, 5, 5)},
        {"Vampire", new Vampire(100, 100, 120, 50, 300, 300, 2, 2)},
        {"Kamikaze", new Kamikaze(50, 125, 20, 75, 500, 500, 6, 6)},
        {"Pretre", new Pretre(75, 125, 50, 50, 150, 150, 1, 1)}
    };


    /// <summary>Ask for a number of character by team</summary>
    public static int ChooseNumber()
    {
        Console.Write("Choose number of characters for our team");
        try
        {
            int number = int.Parse(Console.ReadLine());
            if (number <= 0)
                throw new Exception("Choose a positive number");

            return number;
        }
        catch (Exception)
        {
            Console.Write("Please choose a positive number");
            ChooseNumber();
            return 3; // Used to hide error on return type function
        }
    }

    public static List<Character> ChooseCharacter()
    {
        List<Character> ListOfCharacter = new List<Character>();
        // Ask to the user the character he wants
        return ListOfCharacter;
    }
    public static Character ChooseWhoAttack()
    {
        Character choosenCharacter;
        if (!LIST_OF_CHARACTERS.TryGetValue("Guerrier", out choosenCharacter))
            ChooseWhoAttack();
        return choosenCharacter;
    }
}
