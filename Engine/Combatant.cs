using System;
using Domain.Characters;

namespace Engine
{
    public class Combatant
    {
        public Character Character { get; }

        public float Initiative { get; private set; }
        public bool IsDefending { get; private set; }
        public bool HasFled { get; private set; }

        public bool IsAlive => !Character.Health.IsDead && !HasFled;

        public Combatant(Character character)
        {
            Character = character;
        }

        public void AddInitiative()
            => Initiative += Character.Stats.Total.Agility;
        public bool CanAct(float threshold)
            => Initiative >= threshold;
        public void ConsumeTurn(float threshold)
            => Initiative -= threshold;

        public void ResetTurnState()
            => IsDefending = false;

        public void Defend()
            => IsDefending = true;
        public void Flee()
            => HasFled = true;
        
    }
}
