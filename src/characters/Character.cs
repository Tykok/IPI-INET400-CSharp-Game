using Function;
using Main.enumeration;

namespace Characters;

public abstract class Character
{
    public bool AffectedByPain = true;
    public int Attack;


    public CharacterAttackType CharacterAttackType = CharacterAttackType.NORMAL;
    public CharacterType CharacterType = CharacterType.NORMAL;

    /// <summary>
    ///     Define the number of attack of the current round
    /// </summary>
    public int CurrentAttackNumber;


    /// <summary>
    ///     The current life of the character of the current round
    /// </summary>
    public int CurrentLife;

    /// <summary>
    ///     Boolean who indicate if the character is currently affected by pain
    /// </summary>
    public bool CurrentlyAffectedByPain;

    public int Damages;
    public int Defense;
    public int Initiative;
    public int MaximumLife;
    public int NumberOfRoundAffectedByPain = 0;

    /// <summary>
    ///     Define the total number of attack the character can do
    /// </summary>
    public int TotalAttackNumber;

    protected Character(int Attack,
        int Defense,
        int Initiative,
        int Damages,
        int CurrentLife,
        int TotalAttackNumber)
    {
        this.Attack = Attack;
        this.Defense = Defense;
        this.Initiative = Initiative;
        this.Damages = Damages;
        MaximumLife = CurrentLife;
        this.CurrentLife = CurrentLife;
        CurrentAttackNumber = TotalAttackNumber;
        this.TotalAttackNumber = TotalAttackNumber;
    }

    /// <summary>Check if the character is actually dead</summary>
    public bool IsDead()
    {
        return CurrentLife <= 0;
    }


    public virtual int Jet()
    {
        return new Random().Next(1, 101);
    }

    public int JetInitiative()
    {
        var jetInitiative = Initiative + Jet();
        Console.WriteLine("▶️Jet d'intiative " + GetType().Name + ": " + jetInitiative);
        return jetInitiative;
    }

    public bool CanAttack()
    {
        return CurrentAttackNumber > 0 && NumberOfRoundAffectedByPain == 0;
    }

    /// <summary>Return the amount of the character</summary>
    public virtual int JetAttack()
    {
        return Attack + Jet();
    }

    /// <summary>Return the amount of the character</summary>
    public virtual int JetDefense()
    {
        return Defense + Jet();
    }

    public virtual void StartRound()
    {
        if (CurrentLife <= 0)
        {
            return;
        }

        if (CurrentlyAffectedByPain && NumberOfRoundAffectedByPain > 0)
        {
            NumberOfRoundAffectedByPain--;
        }

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

    public virtual void AttackSomeone(List<Character> listOfCharacter)
    {
        var target = ChooseWhoAttack(listOfCharacter);
        // Make two Jet for attack and defense
        var attackLevel = JetAttack();
        var targetDefense = target.JetDefense();
        var attackMargin = attackLevel - targetDefense;

        Console.WriteLine("🗡️jet d'attaque de " + GetType().Name + ": " + (attackLevel - Attack) + " + " + Attack +
                          " = " + attackLevel);
        Console.WriteLine("🛡jet de defense de " + target.GetType().Name + ": " + (targetDefense - Defense) + " + " +
                          Defense + " = " + targetDefense);
        Console.WriteLine("Marge d'attaque: " + attackMargin + "\n");

        // Check if the target can counter
        if (attackMargin <= 0)
        {
            CounterDamage(target, attackMargin * -1);
        }
        else
        {
            MakeDamage(target, attackMargin);
        }

        if (CanAttack())
        {
            AttackSomeone(listOfCharacter);
        }
    }

    /// <summary>Used to make damage to another character</summary>
    protected virtual void MakeDamage(Character target, int attackMargin)
    {
        var newCurrentLife = target.CurrentLife - Weakness(target, attackMargin / 100);
        target.CurrentLife = newCurrentLife < 0 ? 0 : newCurrentLife;
        target.CheckChanceToBeAffectedByPain(attackMargin);
        CurrentAttackNumber--;
        Console.WriteLine("🩸Dégats subis par " + target.GetType().Name + ": " + attackMargin * Damages / 100 + "\n");
    }

    /// <summary>Used to make counter damage to another character</summary>
    protected virtual void CounterDamage(Character counter, int attackMargin)
    {
        Console.WriteLine("💥🔁" + counter.GetType().Name + " contre-attaque " + GetType().Name + "!" + "\n");
        // Check if the counter can always attack
        if (CanAttack())
        {
            var newCurrentLife = counter.CurrentLife - Weakness(this, attackMargin);
            counter.CurrentLife = newCurrentLife < 0 ? 0 : newCurrentLife;
            CheckChanceToBeAffectedByPain(attackMargin);
            CurrentAttackNumber--;
            counter.CurrentAttackNumber--;
            Console.WriteLine("🔥Bonus de contre-attaque: " + attackMargin);
            Console.WriteLine("🩸Dégats subis par " + GetType().Name + ": " + attackMargin);
        }
        else
        {
            Console.WriteLine("❌ La contre attaque a échoué !");
        }
    }


    protected virtual void CheckChanceToBeAffectedByPain(int attackMargin)
    {
        if (!IsDead() && AffectedByPain)
        {
            var chanceToBeAffectedByPain =
                (attackMargin - CurrentLife) * 2 / (CurrentLife + attackMargin);

            // Check if chanceToBeAffectedByPain is higher than 0
            if (chanceToBeAffectedByPain > 0)
            {
                var numberOfRound = new Random().Next(1, 4);
                CurrentlyAffectedByPain = true;
                NumberOfRoundAffectedByPain = numberOfRound;
                Console.WriteLine(
                    $"😰 {GetType().Name} vient d'être affecté par la douleur pendant {numberOfRound} round(s)");
            }
        }
    }

    /// <summary>Double or not the damage given to the target</summary>
    protected int Weakness(Character target, int attackMargin)
    {
        if (target.CharacterType == CharacterType.NORMAL || CharacterAttackType == CharacterAttackType.NORMAL)
        {
            return attackMargin;
        }

        if (target.CharacterType == CharacterType.SACRED && CharacterAttackType == CharacterAttackType.CURSED)
        {
            return attackMargin * 2;
        }

        if (target.CharacterType == CharacterType.UNHOLY && CharacterAttackType == CharacterAttackType.BLESSED)
        {
            return attackMargin * 2;
        }

        return attackMargin;
    }
}
