using Characters;
using Characters;
using Figgle;

namespace Function;

public class ConsoleInterraction
{
    public static int GetNumberOfFighters()
    {
        Console.WriteLine(FiggleFonts.Slant.Render("Console Battle"));
        Console.WriteLine("Veuillez sélectionner un mode de jeu...");
        Console.WriteLine("Duel (tapez d) | Battle Royal (tapez b)");
        var mode = new string(Console.ReadLine());
        var numberOfFighters = 0;

        if (mode == "d")
        {
            numberOfFighters = 2;
            ShowInFiggleFonts("DUEL");
        }
        else
        {
            ShowInFiggleFonts("BATTLE ROYAL");
            numberOfFighters = ChooseNumberOfFighters();
        }

        return numberOfFighters;
    }

    public static void ShowInFiggleFonts(string text)
    {
        Console.WriteLine(FiggleFonts.Slant.Render(text));
    }

    public static int ChooseNumberOfFighters()

    {
        var numberOfFighters = 0;
        do
        {
            Console.WriteLine("Veuillez choisir le nombre de combattants");
            try
            {
                numberOfFighters = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Veuillez entrer un nombre positif entier");
                numberOfFighters = 0;
            }
        } while (numberOfFighters <= 0);

        return numberOfFighters;
    }

    public static void ShowAllDeadCharacter(List<Character> listOfCharacter)
    {
        Console.WriteLine("\nMort(s) :");
        foreach (var character in listOfCharacter)
        {
            Console.WriteLine(character.GetType().Name + " est mort");
        }

        Console.WriteLine();
    }

    public static void ShowLosingClassement(List<Character> listOfLosingCharacter)
    {
        var i = listOfLosingCharacter.Count + 1;
        foreach (var character in listOfLosingCharacter)
        {
            Console.WriteLine(i + " : " + character.GetType().Name);
            i--;
        }
    }

    public static void ResumeOfAllCharacter(List<Character> listOfCharacter)
    {
        Console.WriteLine("Survivant du round :");
        foreach (var character in listOfCharacter)
        {
            Console.WriteLine(character);
        }
    }
}
