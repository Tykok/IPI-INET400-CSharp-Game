namespace Characters;

public class Vampire : Character
{
    public Vampire() : base(100, 100, 120, 50, 300, 2, 2)
    {
    }

    public void Heal()
    {   
         int maxLife = MaximumLife;
        
         if (CurrentLife < MaximumLife)
         
               
                CurrentLife = (base.JetAttack() - base.JetDefense()) / 2;
                if(CurrentLife > MaximumLife)
                {
                    CurrentLife = maxLife;
                }
    }

}
