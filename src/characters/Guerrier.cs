namespace Characters;

public class Guerrier : Character
{
    public Guerrier() : base(100, 100, 50, 100, 200, 2)
    {
    }

    public override int JetAttack()
    {
        if (CurrentlyAffectedByPain)
        {
            CurrentlyAffectedByPain = false;
            return 0;
        }

        return base.JetAttack();
    }

    protected override void CheckChanceToBeAffectedByPain(int attackMargin)
    {
        if (!IsDead())
        {
            var chanceToBeAffectedByPain =
                (attackMargin - CurrentLife) * 2 / (CurrentLife + attackMargin);

            // Check if chanceToBeAffectedByPain is higher than 0
            if (chanceToBeAffectedByPain > 0)
            {
                CurrentlyAffectedByPain = true;
                NumberOfRoundAffectedByPain = 1;
                Console.WriteLine($"😰 {GetType().Name} vient d'être affecté par la douleur pendant 1 round(s)");
            }
        }
    }
}
