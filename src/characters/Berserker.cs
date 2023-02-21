namespace Characters;

public class Berserker : Character
{
    public bool AffectedByPain = false;

    public Berserker() : base(100, 100, 80, 20, 300, 1)
    {
    }

    private int CurrentLife
    {
        get => base.CurrentLife;
        set
        {
            if (CurrentLife < MaximumLife / 2)
            {
                TotalAttackNumber = 4;
            }

            CurrentLife = value;
        }
    }

    public override void StartRound()
    {
        if (CurrentLife <= 0)
        {
            return;
        }

        if (CurrentLife < MaximumLife / 2)
        {
            TotalAttackNumber = 4;
        }

        CurrentAttackNumber = TotalAttackNumber;
    }

    public override int JetAttack()
    {
        var BaseJet = base.JetAttack();
        return BaseJet + (MaximumLife - CurrentLife);
    }
}
