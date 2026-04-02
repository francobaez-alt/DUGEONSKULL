using System;
using Domain.ValueObjects;

namespace Domain.Characters
{
    public class CharacterLevel
    {
        public int Level { get; private set; }
        public Experience XP { get; private set; }

        public event Action<int>? OnLevelUp;

        public CharacterLevel()
        {
            Level = 1;
            XP = new Experience(CalculateXPRequired(Level));
        }
        public void GainXP(int amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            int remainingXP = amount;

            while (remainingXP > 0)
            {
                int overflow = XP.Gain(remainingXP);

                if (!XP.IsFull)
                    break;

                // Level up
                Level++;
                OnLevelUp?.Invoke(Level);

                remainingXP = overflow;

                XP = new Experience(CalculateXPRequired(Level));
            }
        }
        private int CalculateXPRequired(int level)
        => 100 + (level - 1) * 75;

        public override string ToString()
        {
            return
                $"Level: {Level}\n" +
                $"{XP} \n";

        }
    }
}
