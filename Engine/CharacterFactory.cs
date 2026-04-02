using Domain.Characters;
using Domain.Progression;

namespace Engine
{
    public static class CharacterFactory
    {
        public static Character CreateWarrior(string name)
        {
            var progression = new WarriorProgression();

            var character = new Character(name, CharacterClass.Warrior, progression);

            // Base tuning 
           // character.Stats.SetBaseStats(new Stats(12, 5, 0, 10, 5, 0, 2));

            return character;
        }

        public static Character CreateRogue(string name)
        {
            var progression = new RogueProgression();

            var character = new Character(name, CharacterClass.Rogue, progression);

            //character.Stats.SetBaseStats(new Stats(8, 12, 0, 6, 2, 0, 1));

            return character;
        }
    }
}
