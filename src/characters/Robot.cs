using Characters;

public class Robot : Character
{
    public Robot() : base(10, 100, 50, 50, 200,  1, 1)
    {
    }

    public override int Jet() => 50;
}
