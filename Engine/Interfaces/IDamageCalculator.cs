using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Interfaces
{
    public interface IDamageCalculator
    {
        int Calculate(Combatant attacker, Combatant defender);
    }
}
