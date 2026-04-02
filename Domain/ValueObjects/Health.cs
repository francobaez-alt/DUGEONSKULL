using System;

namespace Domain.ValueObjects
{
    public class Health : PointWell
    {
        public bool IsDead => IsEmpty;

        public Health(int max, int initial = -1) : base(max, initial) { }

        public void TakeDamage(int amount)
        {
            if(amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "El daño no puede ser cero");

            Current = Math.Max(Current - amount, 0);
        }

        public void Heal(int amount) => Restore(amount);

    }
}
