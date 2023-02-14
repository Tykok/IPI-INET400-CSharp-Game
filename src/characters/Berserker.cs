namespace Characters;

public class Berserker : Character
{

    public bool AffectedByPain = false;
    
    public Berserker() : base(100, 100, 80, 20, 300, 1, 1)
    {
    }
    
    public int CurrentLife
    {
        get { return CurrentLife; }
        set
        {
            if (CurrentLife < MaximumLife / 2)
                TotalAttackNumber = 4;
            CurrentLife = value;
        }
    }
    
    public override int Jet()
    {
        var BaseJet = base.Jet();
        return BaseJet + (MaximumLife - CurrentLife);
    }
}
