using System;

namespace Domain.ValueObjects
{
    public class Mana : PointWell
    {
        public Mana(int max, int initial = -1) : base(max, initial) { }

        public void Spend(int amount ) => Consume(amount);
        public void Regenerate(int amount) => Restore(amount);
    }
}
