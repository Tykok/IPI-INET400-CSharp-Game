namespace Function;
using Figgle;

public class ConsoleInterraction
{
    public static int GetNumberOfFighters()
    {
        Console.WriteLine(FiggleFonts.Slant.Render("Console Battle"));
        Console.WriteLine("Veuillez sélectionner un mode de jeu...");
        Console.WriteLine("Duel (tapez d) | Battle Royal (tapez b)");
        string mode = new string(Console.ReadLine());
        int numberOfFighters = 0;
        
        if(mode == "d")
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
            }catch(Exception e)
            {
                Console.WriteLine("Veuillez entrer un nombre");
            }
        } while (numberOfFighters > 0);
        return numberOfFighters;
    }
}
