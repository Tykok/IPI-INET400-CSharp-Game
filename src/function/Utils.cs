namespace Function;

using Characters;

public static class UtilsCharacters
{
    public static bool CheckIfSomebodyDie(List<Character> listOfCharacter)
    {
        foreach (var character in listOfCharacter)
        {
            if (character.IsDead())
            {
                return true;
            }
        }

        return false;
    }

    public static Character RandomCharacter()
    {
        var rnd = new Random();
        var random = rnd.Next(1, 11);
        switch (random)
        {
            case 1:
                return new Berserker();
            case 2:
                return new Gardien();
            case 3:
                return new Goule();
            case 4:
                return new Guerrier();
            case 5:
                return new Kamikaze();
            case 6:
                return new Liche();
            case 7:
                return new Pretre();
            case 8:
                return new Robot();
            case 9:
                return new Vampire();
            case 10:
                return new Zombie();
            default:
                return new Berserker();
        }
    }

    public static List<Character> GetAListOfRandomCharacter(int number)
    {
        List<Character> ListOfCharacter = new();
        for (var i = 0; i < number; i++)
        {
            ListOfCharacter.Add(RandomCharacter());
        }

        return ListOfCharacter;
    }

    public static Character GetRandomCharacterInList(List<Character> listOfCharacter)
    {
        return listOfCharacter[new Random().Next(0, listOfCharacter.Count)];
    }

    public static bool SomebodyCanAttack(List<Character> listOfCharacter)
    {
        foreach (var character in listOfCharacter)
        {
            if (character.CanAttack())
            {
                return true;
            }
        }

        return false;
    }

    public static void CharognardEatDeadBody(List<Character> allDeadCharacter, List<Character> listOfCharacter)
    {
        listOfCharacter.FindAll(x => x is Charognard).ForEach(charognard =>
        {
            allDeadCharacter.ForEach(deadCharacter =>
            {
                Console.WriteLine($"\n{charognard.GetType().Name} mange le cadavre de {deadCharacter.GetType().Name}");
                ((Charognard)charognard).EatDeadCharacter();
            });
        });
    }
}
