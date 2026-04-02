using System;

namespace Domain.ValueObjects
{
    public class Experience : PointWell
    {
        public Experience(int maxXP) : base(maxXP, 0) { }

        public override void Consume(int amount)
        {
            throw new InvalidOperationException("El XP no se puede consumir.");
        }
        public int Gain(int amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            int total = Current + amount;

            if(total < Max)
            {
                Current = total;
                return 0;
            }

            int overflow = total - Max;
            Current = Max;
            return overflow;
        }

        public void Reset()
        {
            Current = 0;
        }
    }
}
