namespace Characters;

public abstract class Character
{
    protected virtual int Attack
    {
        get { return Attack; }
        set { Attack = value; }
    }
    protected virtual int Defense
    {
        get { return Defense; }
        set { Defense = value; }
    }
    protected virtual int Initiative
    {
        get { return Initiative; }
        set { Initiative = value; }
    }
    protected virtual int Damages
    {
        get { return Damages; }
        set { Damages = value; }
    }
    protected virtual int MaximumLife
    {
        get { return MaximumLife; }
        set { MaximumLife = value; }
    }
    protected virtual int CurrentLife
    {
        get { return CurrentLife; }
        set { CurrentLife = value; }
    }
    protected virtual int CurrentAttackNumber
    {
        get { return CurrentAttackNumber; }
        set { CurrentAttackNumber = value; }
    }
    protected virtual int TotalAttackNumber
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
    protected virtual bool IsDead() => CurrentLife > 0;

    /// <summary>Return the amount of the character</summary>
    protected virtual int Jet()
    {
        Random rnd = new Random();
        return Attack + rnd.Next(1, 101);
    }

    /// <summary>Return an integer who correspond to the amount of the attack on a character</summary>
    protected virtual int MarginAttack(Character target) => target.Defense - Jet();
}