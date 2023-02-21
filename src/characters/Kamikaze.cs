namespace Characters;

public class Kamikaze : Character
{
    // TODO Chance de 50% d'attaque sur TOUT les personnages du champ de bataille
    public Kamikaze() : base(50, 125, 20, 75, 500, 6)
    {
    }

    protected override void CounterDamage(Character counter, int attackMargin)
    {
        // The kamikaze can't counter
    }

    protected override void MakeDamage(Character target, int attackMargin)
    {
        var newCurrentLife = target.CurrentLife - Weakness(target, attackMargin / 100);
        target.CurrentLife = newCurrentLife < 0 ? 0 : newCurrentLife;

        CurrentAttackNumber = 0;
    }

    public override void AttackSomeone(List<Character> listOfCharacter)
    {
        // Make two Jet for attack and defense
        var attackLevel = JetAttack();

        foreach (var target in listOfCharacter)
        {
            // 50% chance to attack someone
            var impact = new Random().Next(0, 2) == 0;
            if (impact)
            {
                continue;
            }

            var targetDefense = target.JetDefense();
            var attackMargin = attackLevel - targetDefense;

            Console.WriteLine("🗡️jet d'attaque de " + GetType().Name + ": " + (attackLevel - Attack) + " + " + Attack +
                              " = " + attackLevel);
            Console.WriteLine("🛡jet de defense de " + target.GetType().Name + ": " + (targetDefense - Defense) +
                              " + " + Defense + " = " + targetDefense);
            Console.WriteLine("Marge d'attaque: " + attackMargin + "\n");

            // Check if the target can counter
            if (attackMargin > 0)
            {
                Console.WriteLine("💥" + target.GetType().Name + " est touché par l'explosion du Kamikaze !\n");
                MakeDamage(target, attackMargin);
            }
            else
            {
                Console.WriteLine("❌" + target.GetType().Name + " esquive l'explosion du Kamikaze !\n");
            }
        }
    }
}
