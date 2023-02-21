using Main.enumeration;

namespace Characters;

public class Zombie : Character, Charognard, MortVivant
{
    public bool AffectedByPain = false;
    public CharacterType CharacterType = CharacterType.UNHOLY;

    public Zombie() : base(100, 0, 20, 60, 1000, 1)
    {
    }

    public override int JetDefense()
    {
        return 0;
    }

    public void EatDeadCharacter()
    {
        var heal = new Random().Next(50, 101);
        CurrentLife = CurrentLife + heal > MaximumLife ? MaximumLife : CurrentLife + heal;
    }
}
