
using Domain.Characters;

namespace Domain.Progression
{
    public class MagueProgression : IClassProgression
    {
        public Stats GetBaseStats()
        {
            return new Stats(
                strength: 1,
                agility: 3,
                intelligence: 9,
                vitality: 3,
                physicalDefense: 2,
                magicPower: 8,
                shield: 0,
                maxHealth: 20,
                maxMana: 60,
                critChance: 0
            );
        }

        public Stats GetLevelBonus(int level)
        {
            return new Stats(
                strength: 0,
                agility: level * 1,
                intelligence: level * 3,
                vitality: level * 2,
                physicalDefense: level * 1,
                magicPower: level * 4,
                shield: 0,
                maxHealth: level * 6,
                maxMana: level * 12,
                critChance: 0
            );
        }


    }
}
