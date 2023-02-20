namespace Function;
using Characters;

public static class UtilsCharacters
{
    public static Character RandomCharacter()
    {
        Random rnd = new Random();
        int random = rnd.Next(1, 11);
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
        List<Character> ListOfCharacter = new List<Character>();
        for(int i = 0; i < number; i++)
        {
            ListOfCharacter.Add(RandomCharacter());
        }
        return ListOfCharacter;
    }
    
    public static List<Character> OrderByInitiative(List<Character> listOfCharacter)
    {
        List<Character> listOfCharacterOrderByInitiative = new List<Character>();
        listOfCharacterOrderByInitiative = listOfCharacter.OrderBy(x => x.JetInitiative()).ToList();
        return listOfCharacterOrderByInitiative;
    }

    public static Character GetRandomCharacterInList(List<Character> listOfCharacter) =>  listOfCharacter[new Random().Next(0, listOfCharacter.Count)];
}
