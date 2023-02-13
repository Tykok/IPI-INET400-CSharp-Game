namespace Characters;

public class Guerrier : Character
{

    public virtual bool AffectedByPain
    {
        get { return AffectedByPain; }
        set { AffectedByPain = value; }
    }

    public Guerrier() : base(100, 100, 50, 100, 200, 200, 2, 2)
    {
    }

    public override int Jet() {
        if (AffectedByPain) {
            AffectedByPain = false;
            return 0;
        }
        return base.Jet();
    }
}