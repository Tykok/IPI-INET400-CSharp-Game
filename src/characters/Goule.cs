namespace Characters;

public class Goule : Character
{
    public Goule() : base(50, 80, 120, 30, 250,  5, 5)
    {
    }

    /// <summary>
    /// Used to heal the "Goule" if someone dead
    /// </summary>
    public void EatDeadCharacter()
    {
        var heal = new Random().Next(49, 101);
        CurrentLife = CurrentLife + heal > MaximumLife ? MaximumLife : CurrentLife + heal;
    }
}
