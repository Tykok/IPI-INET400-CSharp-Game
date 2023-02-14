namespace Characters;

public class Berserker : Character
{

    public static bool AffectedByPain = false;
    
    public Berserker() : base(100, 100, 80, 20, 300, 1, 1)
    {
    }
    
    private int CurrentLife
    {
        get => base.CurrentLife;
        set
        {
            if (CurrentLife < MaximumLife / 2)
                TotalAttackNumber = 4;
            CurrentLife = value;
        }
    }
    
    public override int JetAttack()
    {
        var BaseJet = base.JetAttack();
        return BaseJet + (MaximumLife - CurrentLife);
    }
}
