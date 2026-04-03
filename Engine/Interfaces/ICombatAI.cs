using System;

namespace Engine.Interfaces
{
    public enum CombatAction
    {
        Attack,
        Defend,
        Flee
    }

    public interface ICombatAI
    {
        CombatAction DecideAction(Combatant self, IEnumerable<Combatant> enemies);
    }
}
