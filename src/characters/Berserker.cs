namespace Characters;

public class Berserker : Character
{
    public Berserker() : base(100, 100, 80, 20, 300, 1, 1)
    {
    }
    
    public int CurrentLife
    {
        get { return CurrentLife; }
        set
        {
            if (CurrentLife < MaximumLife / 2)
                CurrentAttackNumber = 4;
            CurrentLife = value;
        }
    }
    
}
