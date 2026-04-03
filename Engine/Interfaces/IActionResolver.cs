using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Interfaces
{
    public interface IActionResolver
    {
        void Resolve(
            CombatAction action,
            Combatant actor,
            IEnumerable<Combatant> targets);
    }
}
