namespace Characters;
using Main.enumeration;

public class Zombie : Character
{
    
    public static bool AffectedByPain = false;
    public static CharacterType CharacterType = CharacterType.UNHOLY;
    
    public Zombie() : base(100, 0, 20, 60, 1000,  1, 1)
    {
    }

    public override int JetDefense()
    {
        return 0;
    }
}
