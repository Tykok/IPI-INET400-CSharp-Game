using Main.enumeration;

namespace Characters;

public class Liche : Character, MortVivant
{
    public bool AffectedByPain = false;

    public CharacterAttackType CharacterAttackType = CharacterAttackType.CURSED;

    public Liche() : base(75, 125, 80, 50, 125, 3)
    {
    }
}
