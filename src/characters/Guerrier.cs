namespace Characters;

public class Guerrier : Character
{
    public Guerrier() : base(100, 100, 50, 100, 200, 2, 2)
    {
    }

    public override int JetAttack() {
        if (CurrentlyAffectedByPain) {
            CurrentlyAffectedByPain = false;
            return 0;
        }
        return base.JetAttack();
    }
}
