
using Domain.Characters;

namespace Domain.Progression
{
    public class WarriorProgression : IClassProgression
    {
        public Stats GetBaseStats()
        {
            return new Stats(
                strength: 8,
                agility: 3,
                intelligence: 0,
                vitality: 7,
                physicalDefense: 6,
                magicPower: 0,
                shield: 0,
                maxHealth: 50,
                maxMana: 0,
                critChance: 1
            );
        }

        public Stats GetLevelBonus(int level)
        {
            return new Stats(
                strength: level * 2,
                agility: level * 1,
                intelligence: 0,
                vitality: level * 3,
                physicalDefense: level * 3,
                magicPower: 0,
                shield: 0,
                maxHealth: level * 10,
                maxMana: 0,
                critChance: level * 0.15m
            );
        }
    }
}
