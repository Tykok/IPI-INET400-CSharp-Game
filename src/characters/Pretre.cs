using Main.enumeration;
using Function;

namespace Characters;

public class Pretre : Character
{
    // TODO Cible en priorité les personnages de type UNHOLY

    public CharacterType CharacterType = CharacterType.SACRED;

    public Pretre() : base(75, 125, 50, 50, 150, 1)
    {
    }

    protected override Character ChooseWhoAttack(List<Character> listOfCharacter)
    {
        var copyOfList = new List<Character>(listOfCharacter);
        // Remove us from list 
        copyOfList.Remove(this);
        Character target;

        if (copyOfList.Exists(x => x is MortVivant))
        {
            Console.WriteLine("🧎🏽 Le prêtre cible un mort vivant en priorité !");
            target = copyOfList.Find(x => x is MortVivant);
        }
        else
        {
            target = UtilsCharacters.GetRandomCharacterInList(copyOfList); // Return a random character
        }

        return target;
    }

    public override void StartRound()
    {
        base.StartRound();

        var heal = (int)(MaximumLife * 0.1);

        // If the priest is still alive, he will heal himself by 10% of his maximum life
        CurrentLife = heal + CurrentLife > MaximumLife ? MaximumLife : CurrentLife + heal;
    }
}
