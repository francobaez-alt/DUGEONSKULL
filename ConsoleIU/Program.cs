using Domain.Characters;
using Domain.Items;
using Domain.Progression;
using Engine;

internal class Program
{
    private static void Main(string[] args)
    {
        var Warrior = CharacterFactory.CreateWarrior("PRIME WARRIOR");

        Console.WriteLine(Warrior.ToString());

        Warrior.GainExperience(50);

        Console.WriteLine(Warrior.ToString());

        Warrior.GainExperience(50);

        Console.WriteLine(Warrior.ToString());

        Warrior.GainExperience(2000);

        Console.WriteLine(Warrior.ToString());
    }
}