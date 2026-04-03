using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Interfaces;

namespace Engine
{
    public class BasicActionResolver : IActionResolver
    {
        private readonly IDamageCalculator _damageCalculator;

        public BasicActionResolver(IDamageCalculator damageCalculator)
        {
            _damageCalculator = damageCalculator;
        }

        public void Resolve(CombatAction action, 
            Combatant actor, 
            IEnumerable<Combatant> targets)
        {
            switch(action)
            { 
                case CombatAction.Attack:
                    ResolveAttack(actor, targets);
                    break;
                case CombatAction.Defend:
                    actor.Defend();
                    Console.WriteLine($"{actor.Character.Name} se defiende");
                    break;
                case CombatAction.Flee:
                    actor.Flee();
                    Console.WriteLine($"{actor.Character.Name} huyo!");
                    break;
             }
        }

        private void ResolveAttack(Combatant attacker, IEnumerable<Combatant> targets) 
        {
            var validTargets = targets.Where(t => t.IsAlive).ToList();
            if (!validTargets.Any())
                return;

            var target = validTargets[Random.Shared.Next(validTargets.Count)];

            int damage = _damageCalculator.Calculate(attacker, target);

            target.Character.Health.TakeDamage(damage);

            Console.WriteLine(
                $"{attacker.Character.Name} ataca a {target.Character.Name} por {damage} daño " +
                $"(HP: {target.Character.Health.Current}/{target.Character.Health.Max})"
            );
        }
    }
}
