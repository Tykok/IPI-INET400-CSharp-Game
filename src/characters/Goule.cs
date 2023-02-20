namespace Characters;

public class Goule : Character, Charognard, MortVivant
{
    public Goule() : base(50, 80, 120, 30, 250, 5)
    {
    }

    public void EatDeadCharacter()
    {
        var heal = new Random().Next(50, 101);
        CurrentLife = CurrentLife + heal > MaximumLife ? MaximumLife : CurrentLife + heal;
    }
}
