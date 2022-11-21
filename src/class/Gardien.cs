namespace Class;

public class Gardien : Character
{
    public Gardien(int Attack,
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