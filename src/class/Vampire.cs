namespace Class;

public class Vampire : Character
{
    public Vampire(int Attack,
                    int Defense,
                    int Initiative,
                    int Damages,
                    int MaximumLife,
                    int CurrentLife,
                    int CurrentAttackNumber,
                    int TotalAttackNumber) : base(Attack, Defense, Initiative, Damages, MaximumLife, CurrentLife, CurrentAttackNumber, TotalAttackNumber)
    {
    }
}