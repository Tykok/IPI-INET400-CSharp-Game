using Main.enumeration;
namespace Characters;

public class Gardien : Character
{

    public CharacterType CharacterType = CharacterType.SACRED;
    public CharacterAttackType CharacterAttackType = CharacterAttackType.BLESSED;
    public Gardien() : base(50, 150, 50, 50, 150,  3, 3)
    {
    }

    protected override void CounterDamage(Character target, int attackMargin)
    {
        CurrentLife -= attackMargin * 2;
        target.CurrentAttackNumber--;
        CurrentAttackNumber--;
    }
}
