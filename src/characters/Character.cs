using System.Reflection.Metadata.Ecma335;
using Main.enumeration;
namespace Characters;

public abstract class Character
{

    public static CharacterType CharacterType = CharacterType.NORMAL;
    public static CharacterAttackType CharacterAttackType = CharacterAttackType.NORMAL;
    public static bool AffectedByPain = true;

    public int Attack;
    public int Defense;
    public int Initiative;
    public int Damages;
    public int MaximumLife;
    
    
    /// <summary>
    /// The current life of the character of the current round
    /// </summary>
    public int CurrentLife;
    
    /// <summary>
    /// Define the number of attack of the current round
    /// </summary>
    public int CurrentAttackNumber;
    
    /// <summary>
    /// Define the total number of attack the character can do
    /// </summary>
    public int TotalAttackNumber;

    /// <summary>
    /// Boolean who indicate if the character is currently affected by pain
    /// </summary>
    public bool CurrentlyAffectedByPain;

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


    public virtual int Jet() => new Random().Next(1, 101);
    
    /// <summary>Return the amount of the character</summary>
    public virtual int JetAttack()
    {
        if (CurrentAttackNumber == 0)
            throw new Exception("The character can't attack anymore");
        
        if (CurrentlyAffectedByPain)
            throw new Exception("The character is affected by pain");
        return Attack + Jet();
    }
    
    /// <summary>Return the amount of the character</summary>
    public virtual int JetDefense()
    {
        return Defense + Jet();
    }

    /// <summary>Return an integer who correspond to the amount of the attack on a character</summary>
    public virtual int MarginAttack(Character target) => target.Defense - JetAttack();

    public virtual void AttackCharacter(Character target)
    {
        target.CurrentLife -= JetAttack() - target.Defense;
    }
    

    public virtual void StartRound() {
        if (CurrentLife <= 0)
            return;
        
        CurrentAttackNumber = TotalAttackNumber;
    }
    
    /// <summary>Return a string who describe the character</summary>
    public virtual string ToString()
    {
        return "Attack: " + Attack + " Defense: " + Defense + " Initiative: " + Initiative + " Damages: " + Damages +
               " MaximumLife: " + MaximumLife + " CurrentLife: " + CurrentLife + " CurrentAttackNumber: " +
               CurrentAttackNumber + " TotalAttackNumber: " + TotalAttackNumber;
    }
    
    /// <summary>
    /// Return an Integer who indicate the attack margin on the target.
    /// This Integer can be negative if the target can counter the attack, or positive if the attack is successful.
    /// </summary>
    public virtual int AttackSomeone(Character target)
    {
        
        // Make two Jet for attack and defense
        var attackLevel = JetAttack();
        var targetDefense = target.JetDefense();
        var attackMargin = attackLevel - targetDefense;
        
        // Check if the target can counter
        if (targetDefense > attackLevel)
        {
            CounterDamage(target, attackMargin * -1);
            return attackMargin;
        }
        
        MakeDamage(target, attackMargin);
        return attackMargin;
    }

    /// <summary>Used to make damage to another character</summary>
    protected virtual void MakeDamage(Character target, int attackMargin)
    {
        target.CurrentLife -= attackMargin;
        target.CurrentAttackNumber--;
    }
    
    /// <summary>Used to make counter damage to another character</summary>
    protected virtual void CounterDamage(Character target, int attackMargin)
    {
        CurrentLife -= attackMargin;
        target.CurrentAttackNumber--;
    }
}
