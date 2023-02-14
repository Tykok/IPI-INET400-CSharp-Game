namespace Characters;
using Main.enumeration;

public class Pretre : Character
{
    public CharacterType CharacterType = CharacterType.SACRED;
    public CharacterAttackType CharacterAttackType = CharacterAttackType.BLESSED;

    public Pretre() : base(75, 125, 50, 50, 150,  1, 1)
    {
    }


    public override void StartRound()
    {
        base.StartRound();

        var heal = (int)(MaximumLife * 0.1);
        
        // If the priest is still alive, he will heal himself by 10% of his maximum life
        CurrentLife = heal + CurrentLife > MaximumLife ? MaximumLife : CurrentLife + heal;
    }
}
