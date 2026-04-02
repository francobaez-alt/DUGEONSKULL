using System;
using Domain.Characters;

namespace Domain.Items
{
    public abstract class Item
    {
        public string Name { get; }
        public Stats BonusStats { get; }
        public string Description { get; }

        protected Item(string name, Stats bonusStats, string description = " ")
        {
            Name = name;
            BonusStats = bonusStats;
            Description = description;

        }
    }
}
