using System;

namespace Domain.Characters
{
    public class Stats
    {
        public int Strength { get; }
        public int Agility { get; }
        public int Intelligence { get; }
        public int Vitality { get; }

        public int PhysicalDefense { get; }
        public int MagicPower { get; }

        public int Shield { get; }

        public int MaxHealth { get; }
        public int MaxMana { get; }

        public decimal CritChance { get; }

        public Stats(
            int strength = 0,
            int agility = 0,
            int intelligence = 0,
            int vitality = 0,
            int physicalDefense = 0,
            int magicPower = 0,
            int shield = 0,
            int maxHealth = 0,
            int maxMana = 0,
            decimal critChance = 0)
        {
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
            Vitality = vitality;
            PhysicalDefense = physicalDefense;
            MagicPower = magicPower;
            Shield = shield;
            MaxHealth = maxHealth;
            MaxMana = maxMana;
            CritChance = critChance;
        }

        public Stats Add(Stats bonus)
        {
            if (bonus is null)
                throw new ArgumentNullException(nameof(bonus));

            return new Stats(
                strength: Strength + bonus.Strength,
                agility: Agility + bonus.Agility,
                intelligence: Intelligence + bonus.Intelligence,
                vitality: Vitality + bonus.Vitality,
                physicalDefense: PhysicalDefense + bonus.PhysicalDefense,
                magicPower: MagicPower + bonus.MagicPower,
                shield: Shield + bonus.Shield,
                maxHealth: MaxHealth + bonus.MaxHealth,
                maxMana: MaxMana + bonus.MaxMana,
                critChance: CritChance + bonus.CritChance
            );
        }

        public static Stats operator +(Stats a, Stats b)
        {
            if (a is null) return b;
            return a.Add(b);
        }

        public static Stats operator -(Stats a, Stats b)
        {
            return new Stats(
                a.Strength - b.Strength,
                a.Agility - b.Agility,
                a.Intelligence - b.Intelligence,
                a.Vitality - b.Vitality,
                a.PhysicalDefense - b.PhysicalDefense,
                a.MagicPower - b.MagicPower,
                a.Shield - b.Shield
            );
        }


        public static Stats Zero => new Stats();

        public override string ToString()
        {
            return
                $"STR: {Strength}\n" +
                $"AGI: {Agility}\n" +
                $"INT: {Intelligence}\n" +
                $"VIT: {Vitality}\n" +
                $"DEF: {PhysicalDefense}\n" +
                $"M.PWR: {MagicPower}\n" +
                $"SHIELD: {Shield}\n" +
                $"HP: {MaxHealth}\n" +
                $"MP: {MaxMana}";
        }

    }
}
