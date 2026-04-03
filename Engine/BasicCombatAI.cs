using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Interfaces;

namespace Engine
{
    public class BasicCombatAI : ICombatAI
    {
        public CombatAction DecideAction(Combatant self, IEnumerable<Combatant> enemies)
        {
            var hpPercent = (float)self.Character.Health.Current / self.Character.Health.Max;

            if(hpPercent < 0.2f && Random.Shared.NextDouble() < 0.5)
                return CombatAction.Flee;

            if (hpPercent < 0.4f && Random.Shared.NextDouble() < 0.3)
                return CombatAction.Defend;

            return CombatAction.Attack;
        }
    }
}
