using System;
using Domain.Items;

namespace Domain.Characters
{
    public class CharacterStats
    {
        public Stats BaseStats { get; private set; }
        public Stats EquipmentBonus { get; private set; }
        public Stats BuffBonus { get; private set; }
        public Stats LevelBonus { get; private set; }

        public event Action<int>? MaxHealthChange; 

        public Stats Total { get; private set; }

        public CharacterStats(Stats baseStats)
        {
            BaseStats = baseStats ?? throw new ArgumentNullException(nameof(baseStats));
            EquipmentBonus = Stats.Zero;
            BuffBonus = Stats.Zero;
            LevelBonus = Stats.Zero;
            Total = Stats.Zero;
            Recalculate();
        }

        public void SetBaseStats(Stats stats)
        {
            BaseStats = stats ?? Stats.Zero;
            Recalculate();
        }

        public void AddEquipmentBonus(Stats bonus)
        {
            EquipmentBonus += bonus ?? Stats.Zero;
            Recalculate();
        }

        public void RemoveEquipmentBonus(Stats bonus)
        {
            EquipmentBonus -= bonus ?? Stats.Zero;
            Recalculate();
        }

        public void RebuildEquipmentBonus(IEnumerable<EquipableItem> items)
        {
            EquipmentBonus = Stats.Zero;

            foreach (var item in items)
                EquipmentBonus += item.BonusStats;

            Recalculate();
        }

        public void SetBuffBonus(Stats bonus)
        {
            BuffBonus = bonus ?? Stats.Zero;
            Recalculate();
        }

        public void SetLevelBonus(Stats bonus)
        {
            LevelBonus = bonus ?? Stats.Zero;
            Recalculate();
        }

        private void Recalculate()
        {
            int oldMaxHealth = Total.MaxHealth;

            Total =
                BaseStats
                + EquipmentBonus
                + BuffBonus
                + LevelBonus;
            
            int newMaxHealth = Total.MaxHealth;

            if( newMaxHealth != oldMaxHealth)
            {
                MaxHealthChange?.Invoke(newMaxHealth);
            }
        }

        public int GetMaxHealth() => Total.MaxHealth;

        public int GetMaxMana() => Total.MaxMana;

        public override string ToString()
        {
            return
                $"=== CHARACTER STATS ===\n" +
                $"Base Stats:\n{BaseStats}\n\n" +

                $"Equipment Bonus:\n{EquipmentBonus}\n\n" +
                $"Buff Bonus:\n{BuffBonus}\n\n" +
                $"Level Bonus:\n{LevelBonus}\n\n" +

                $"------------------------\n" +
                $"TOTAL:\n{Total}\n" +
                $"========================";
        }
        

    }
}