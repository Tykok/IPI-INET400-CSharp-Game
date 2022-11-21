namespace Class;

public abstract class Character
{
    protected int Attack
    {
        get { return Attack; }
        set { Attack = value; }
    }
    protected int Defense
    {
        get { return Defense; }
        set { Defense = value; }
    }
    protected int Initiative
    {
        get { return Initiative; }
        set { Initiative = value; }
    }
    protected int Damages
    {
        get { return Damages; }
        set { Damages = value; }
    }
    protected int MaximumLife
    {
        get { return MaximumLife; }
        set { MaximumLife = value; }
    }
    protected int CurrentLife
    {
        get { return CurrentLife; }
        set { CurrentLife = value; }
    }
    protected int CurrentAttackNumber
    {
        get { return CurrentAttackNumber; }
        set { CurrentAttackNumber = value; }
    }
    protected int TotalAttackNumber
    {
        get { return TotalAttackNumber; }
        set { TotalAttackNumber = value; }
    }

    protected Character(int Attack,
                    int Defense,
                    int Initiative,
                    int Damages,
                    int MaximumLife,
                    int CurrentLife,
                    int CurrentAttackNumber,
                    int TotalAttackNumber)
    {
        this.Attack = Attack;
        this.Defense = Defense;
        this.Initiative = Initiative;
        this.Damages = Damages;
        this.MaximumLife = MaximumLife;
        this.CurrentLife = CurrentLife;
        this.CurrentAttackNumber = CurrentAttackNumber;
        this.TotalAttackNumber = TotalAttackNumber;
    }

    /// <summary>Check if the character is actually dead</summary>
    protected bool IsDead() => CurrentLife > 0;

    /// <summary>Return the amount of the character</summary>
    protected int Jet()
    {
        Random rnd = new Random();
        return Attack + rnd.Next(1, 101);
    }
}