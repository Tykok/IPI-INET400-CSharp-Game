using Main.enumeration;

namespace Characters;

public class Vampire : Character, MortVivant
{
    public bool AffectedByPain = false;

    public CharacterType CharacterType = CharacterType.UNHOLY;

    public Vampire() : base(100, 100, 120, 50, 300, 2)
    {
    }

    protected override void MakeDamage(Character target, int attackMargin)
    {
        base.MakeDamage(target, attackMargin);
        Heal();
    }

    private void Heal()
    {
        var maxLife = MaximumLife;

        if (CurrentLife < MaximumLife)
        {
            CurrentLife = (base.JetAttack() - base.JetDefense()) / 2;
        }

        if (CurrentLife > MaximumLife)
        {
            CurrentLife = maxLife;
        }
    }
}
