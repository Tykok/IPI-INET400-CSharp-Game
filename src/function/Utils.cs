namespace Utils;
using Characters;

public static class UtilsChara
{

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
}
