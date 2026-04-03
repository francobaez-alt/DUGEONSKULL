using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Interfaces;

namespace Engine
{
    public class BasicDamageCalculator : IDamageCalculator
    {
        public int Calculate(Combatant attacker, Combatant defender)
        {
            int attack = attacker.Character.Stats.Total.Strength;
            int defense = defender.Character.Stats.Total.PhysicalDefense;

            if (defender.IsDefending)
                defense *= 2;

            int damage = attack - defense;

            return Math.Max(1, damage);
        }
    }
}
