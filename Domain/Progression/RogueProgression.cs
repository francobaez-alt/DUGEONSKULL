
using Domain.Characters;

namespace Domain.Progression
{
    public class RogueProgression : IClassProgression
    {
        public Stats GetBaseStats()
        {
            return new Stats(
                strength: 4,
                agility: 8,
                intelligence: 1,
                vitality: 4,
                physicalDefense: 3,
                magicPower: 0,
                shield: 0,
                maxHealth: 30,
                maxMana: 10,
                critChance: 5
            );
        }

        public Stats GetLevelBonus(int level)
        {
            return new Stats(
                strength: level * 2,
                agility: level * 4,
                intelligence: 0,
                vitality: level * 2,
                physicalDefense: level * 1,
                magicPower: 0,
                shield: 0,
                maxHealth: level * 7,
                maxMana: level * 3,
                critChance: level * 0.5m
            );
        }
    }
}
