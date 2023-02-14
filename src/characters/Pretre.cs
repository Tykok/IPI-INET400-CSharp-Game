namespace Characters;
using Main.enumeration;

public class Pretre : Character
{
    public CharacterType CharacterType = CharacterType.SACRED;
    public CharacterAttackType CharacterAttackType = CharacterAttackType.BLESSED;

    public Pretre() : base(75, 125, 50, 50, 150,  1, 1)
    {
    }


    public override void ResetRound()
    {
        base.ResetRound();
        
        // If the priest is still alive, he will heal himself by 10% of his maximum life
        CurrentLife+= Convert.ToInt32(MaximumLife * 0.1);
    }
}
