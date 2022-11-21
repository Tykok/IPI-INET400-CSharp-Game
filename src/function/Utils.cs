namespace Utils;
using Class;

public static class Utils
{

    /// <summary>Contains the list of available Characters</summary>
    private static readonly Character[] ListOfChracters = {
        new Guerrier(100, 100, 50, 100, 200, 200, 2, 2),
        new Gardien(50, 150, 50, 50, 150, 150, 3, 3),
        new Berserker(100, 100, 80, 20, 300, 300, 1, 1),
        new Zombie(100, 0, 20, 60, 1000, 1000, 1, 1),
        new Robot(10, 100, 50, 50, 200, 200, 1, 1),
        new Liche(75, 125, 80, 50, 125, 125, 3, 3),
        new Goule(50, 80, 120, 30, 250, 250, 5, 5),
        new Vampire(100, 100, 120, 50, 300, 300, 2, 2),
        new Kamikaze(50, 125, 20, 75, 500, 500, 6, 6),
        new Pretre(75, 125, 50, 50, 150, 150, 1, 1)
    };

}