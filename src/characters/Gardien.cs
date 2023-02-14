using Main.enumeration;
namespace Characters;

public class Gardien : Character
{
    
    public CharacterAttackType CharacterAttackType = CharacterAttackType.BLESSED;
    public Gardien() : base(50, 150, 50, 50, 150,  3, 3)
    {

        
    }

      protected override void CounterDamage(Character target, int attackMargin)
    {
        CurrentLife -= base.Weakness(this, attackMargin) * 2;
        CurrentAttackNumber--;
        target.CurrentAttackNumber--;
    }
}
