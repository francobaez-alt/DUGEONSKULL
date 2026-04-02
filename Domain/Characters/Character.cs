using System;
using Domain.Items;
using Domain.Progression;
using Domain.ValueObjects;

namespace Domain.Characters
{
    public enum CharacterClass{
        Warrior,
        Mague,
        Rogue
    }
    public class Character
    {
        public string Name { get; }
        public CharacterClass Class { get; }

        public CharacterLevel LevelSystem { get; }
        public CharacterStats Stats { get; }
        public Equipment Equipment { get; }

        private readonly IClassProgression _progression;

        public Health Health { get; protected set; }
        public Mana? Mana { get; protected set; }

        public Character(string name, CharacterClass characterClass, IClassProgression progression)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Class = characterClass;

            _progression = progression ?? throw new ArgumentNullException(nameof(progression));

            // Crear sistemas internos
            LevelSystem = new CharacterLevel();
            Stats = new CharacterStats(_progression.GetBaseStats());
            Health = new Health(Stats.GetMaxHealth());
            Equipment = new Equipment();

            // Suscribirse al evento
            LevelSystem.OnLevelUp += HandleLevelUp;
            Stats.MaxHealthChange += HandleMaxHealthChange;
            Equipment.OnItemEquipped += OnItemEquipped;
            Equipment.OnItemUnequipped += OnItemUnequipped;
        }

        private void HandleLevelUp(int newLevel)
        {
            var levelBonus = _progression.GetLevelBonus(newLevel);
            Stats.SetLevelBonus(levelBonus);

            Console.WriteLine($"{Name} subió a nivel {newLevel}!");
        }

        private void HandleMaxHealthChange(int newMaxHealth)
        {
            int oldMax = Health.Max;

            Health.SetMax(newMaxHealth);

            float percentage = (float)Health.Current / oldMax;
            Health.SetCurrent((int)(newMaxHealth * percentage));
        }

        private void OnItemEquipped(EquipableItem item)
        {
            Stats.AddEquipmentBonus(item.BonusStats);
        }

        private void OnItemUnequipped(EquipableItem item)
        {
            Stats.RemoveEquipmentBonus(item.BonusStats);
        }

        public void GainExperience(int amount)
        {
            LevelSystem.GainXP(amount);
        }

        public override string ToString()
        {
            return
                $"=== CHARACTER STATS ===\n" +
                $"{Name}\n" +
                $"{Health}\n"+
                $"{Mana}\n" +
                $"{LevelSystem}" +
                $"{Stats.Total.ToString()}\r\n";
        }


    }
}
