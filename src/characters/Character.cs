using Function;
using Main.enumeration;
namespace Characters;

public abstract class Character
{

    public static bool AffectedByPain = true;


    public CharacterAttackType CharacterAttackType = CharacterAttackType.NORMAL;
    public CharacterType CharacterType = CharacterType.NORMAL;
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
    public bool IsDead() => CurrentLife <= 0;


    public virtual int Jet() => new Random().Next(1, 101);

    public int JetInitiative()
    {
        var jetInitiative = Initiative + Jet();
        Console.WriteLine("▶️Jet d'intiative " + GetType().Name + ": " + jetInitiative);
        return jetInitiative;
    }
    
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
    public override string ToString()
    {
        return "Type: " + GetType().Name + "\n"
               + "Attack: " + Attack + "\n"
               + "Defense: " + Defense + "\n"
               + "Initiative: " + Initiative + "\n"
               + "Damages: " + Damages + "\n"
               + "CurrentLife: " + CurrentLife + "\n"
               + "CurrentAttackNumber: " + CurrentAttackNumber + "\n"
               + "TotalAttackNumber: " + TotalAttackNumber + "\n";
    }
    
    protected virtual Character ChooseWhoAttack(List<Character> listOfCharacter)
    {
        var copyOfList = new List<Character>(listOfCharacter);
        // Remove us from list 
        copyOfList.Remove(this);
        
        // Return a random character
        var target = UtilsCharacters.GetRandomCharacterInList(copyOfList);
        return target;
    }

    public void AttackSomeone(List<Character> listOfCharacter)
    {
        var target = ChooseWhoAttack(listOfCharacter);
        // Make two Jet for attack and defense
        var attackLevel = JetAttack();
        var targetDefense = target.JetDefense();
        var attackMargin = attackLevel - targetDefense;
        
        Console.WriteLine("🗡️jet d'attaque de " + GetType().Name + ": " + (attackLevel - Attack) + " + " + Attack + " = " + attackLevel);
        Console.WriteLine("🛡jet de defense de " + target.GetType().Name + ": " + (targetDefense - Defense) + " + " + Defense + " = " + targetDefense);
        Console.WriteLine("Marge d'attaque: " + attackMargin + "\n");
        
        // Check if the target can counter
        if (attackMargin <= 0)
        {
            Console.WriteLine("💥🔁" + target.GetType().Name + " contre-attaque " + GetType().Name + "!" + "\n");
            CounterDamage(this, attackMargin * -1);
        }
        
        MakeDamage(target, attackMargin);
        
        if(CurrentAttackNumber > 0)
            AttackSomeone(listOfCharacter);
    }

    /// <summary>Used to make damage to another character</summary>
    protected virtual void MakeDamage(Character target, int attackMargin)
    {
        var newCurrentLife = target.CurrentLife - Weakness(target, attackMargin / 100);
        target.CurrentLife = (newCurrentLife < 0 ?  0 : newCurrentLife);
        
        CurrentAttackNumber--;
        Console.WriteLine("🩸Dégats subis par " + target.GetType().Name + ": " + attackMargin * Damages / 100 + "\n");
    }
    
    /// <summary>Used to make counter damage to another character</summary>
    protected virtual void CounterDamage(Character target, int attackMargin)
    {
        // Check if the target can always attack
        if (target.CurrentAttackNumber > 0)
        {
            var newCurrentLife = target.CurrentLife - Weakness(this, attackMargin );
            target.CurrentLife = (newCurrentLife < 0 ? 0 : newCurrentLife);
            
            CurrentAttackNumber--;
            target.CurrentAttackNumber--;
            Console.WriteLine("🔥Bonus de contre-attaque: " + attackMargin);
            Console.WriteLine("🩸Dégats subis par " + GetType().Name + ": " + attackMargin);
        }
        else
        {
            Console.WriteLine("❌ La contre attaque a échoué !");
        }
    }

    /// <summary>Double or not the damage given to the target</summary>
    protected int Weakness(Character target, int attackMargin)
    {
        if(target.CharacterType == CharacterType.NORMAL || CharacterAttackType == CharacterAttackType.NORMAL)
            return attackMargin;
        
        if(target.CharacterType == CharacterType.SACRED && CharacterAttackType == CharacterAttackType.CURSED)
            return attackMargin * 2;
        
        if(target.CharacterType == CharacterType.UNHOLY && CharacterAttackType == CharacterAttackType.BLESSED)
            return attackMargin * 2;

        return attackMargin;
    }
}
