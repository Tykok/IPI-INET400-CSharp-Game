namespace Characters;

public abstract class Character
{
    public int Attack;
    public int Defense;
    public int Initiative;
    public int Damages;
    public int MaximumLife;
    public int CurrentLife;
    public int CurrentAttackNumber;
    public int TotalAttackNumber;
    public bool AffectedByPain;

    protected Character(int Attack,
                    int Defense,
                    int Initiative,
                    int Damages,
                    int CurrentLife,
                    int CurrentAttackNumber,
                    int TotalAttackNumber)
    {
        this.Attack = Attack;
        this.Defense = Defense;
        this.Initiative = Initiative;
        this.Damages = Damages;
        this.MaximumLife = CurrentLife;
        this.CurrentLife = CurrentLife;
        this.CurrentAttackNumber = CurrentAttackNumber;
        this.TotalAttackNumber = TotalAttackNumber;
    }

    /// <summary>Check if the character is actually dead</summary>
    public virtual bool IsDead() => CurrentLife > 0;

    /// <summary>Return the amount of the character</summary>
    public virtual int Jet()
    {
        if (CurrentAttackNumber == 0)
            throw new Exception("The character can't attack anymore");
        
        if (AffectedByPain)
            throw new Exception("The character is affected by pain");
        
        Random rnd = new Random();
        return Attack + rnd.Next(1, 101);
        }

    /// <summary>Return an integer who correspond to the amount of the attack on a character</summary>
    public virtual int MarginAttack(Character target) => target.Defense - Jet();

    public virtual void AttackCharacter(Character target)
    {
        target.CurrentLife -= Jet() - target.Defense;
    }

    /// <summary>Return a string who describe the character</summary>
    public virtual string ToString()
    {
        return "Attack: " + Attack + " Defense: " + Defense + " Initiative: " + Initiative + " Damages: " + Damages + " MaximumLife: " + MaximumLife + " CurrentLife: " + CurrentLife + " CurrentAttackNumber: " + CurrentAttackNumber + " TotalAttackNumber: " + TotalAttackNumber;
    }
}
