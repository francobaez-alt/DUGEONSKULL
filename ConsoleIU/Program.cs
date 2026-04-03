using Domain.Characters;
using Domain.Items;
using Domain.Progression;
using Engine;


internal class Program
{
    private static void Main(string[] args)
    {
        /*var Warrior = CharacterFactory.CreateWarrior("PRIME WARRIOR");

        Console.WriteLine(Warrior.ToString());

        Warrior.GainExperience(50);

        Console.WriteLine(Warrior.ToString());

        Warrior.GainExperience(50);

        Console.WriteLine(Warrior.ToString());

        Warrior.GainExperience(2000);

        Console.WriteLine(Warrior.ToString());

        var Weapon = new Weapon("Espada de Hueso", new Stats(7, 0, 0, 10, 0, 0, 0, 0, 0, 5));

        Console.WriteLine(Weapon.ToString());

        Console.WriteLine($"{Warrior.Name} Se equipa la {Weapon.Name}");
        Console.WriteLine();

        Warrior.Equipment.Equip(Weapon);

        Console.WriteLine(Warrior.ToString() );

        Console.WriteLine($"{Warrior.Name} Se desequipa la {Weapon.Name}");
        Console.WriteLine();

        Warrior.Equipment.Unequip(EquipmentSlot.Weapon);

        Console.WriteLine(Warrior.ToString());*/
        var p1 = CharacterFactory.CreateWarrior("Warrior");
        var p2 = CharacterFactory.CreateRogue("Rogue");

        var ai = new BasicCombatAI();
        var dmg = new BasicDamageCalculator();
        var resolver = new BasicActionResolver(dmg);

        var combat = new CombatSystem(new[] { p1, p2 }, ai, resolver);

        combat.Start();

    }
}