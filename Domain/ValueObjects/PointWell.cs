using System;

namespace Domain.ValueObjects
{
    public abstract class PointWell
    {
        public int Current { get; protected set; }
        public int Max { get; protected set; }

        public bool IsEmpty => Current == 0;
        public bool IsFull => Current == Max;
        public int Missing => Max - Current;

        protected PointWell(int max, int initial = -1) 
        {
            if (max <= 0)
                throw new ArgumentOutOfRangeException(nameof(max), "Max points tiene que ser mayor a cero.");

            Max = max;
            Current = initial < 0 ? max : initial ;

            ValidateCurrent();
        }
        public void SetMax(int newMax)
        {
            if (newMax <= 0)
                throw new ArgumentOutOfRangeException(nameof(newMax));

            Max = newMax;

            if (Current > Max)
                Current = Max;
        }

        public void SetCurrent(int value)
        {
            Current = Math.Clamp(value, 0, Max);
        }
        public virtual void Restore(int amount)
        {
            if (amount <= 0) 
                throw new ArgumentOutOfRangeException(nameof(amount));

            Current = Math.Min(Current +  amount, Max);
        }
        public virtual void Consume(int amount)
        {
            if(amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (amount > Current)
                throw new InvalidOperationException("Puntos Insuficientes");

            Current -= amount;
        }

        public void IncreaseMax(int amount)
        {
            if(amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            Max += amount;
            Current = Math.Min(Current, Max);
        }

        public void ReduceMax(int amount)
        {
            if(amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            if (amount >= Max)
                throw new InvalidOperationException("Max no pude reducirse a 0");

            Max -= amount;
            Current = Math.Min(Current, Max);
        }

        public void Refill() => Current = Max;
        public void Empty() => Current = 0;
        protected void ValidateCurrent()
        {
            if (Current < 0)
                throw new ArgumentOutOfRangeException(nameof(Current));

            if (Current > Max)
                throw new ArgumentOutOfRangeException(nameof(Current));
        }

        public override string ToString() => $"{GetType().Name}: {Current}/{Max}";

    }
}
