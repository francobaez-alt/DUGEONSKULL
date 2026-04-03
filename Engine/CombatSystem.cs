using Domain.Characters;
using Engine.Interfaces;

namespace Engine
{
    public class CombatSystem
    {
        private const float TURN_THRESHOLD = 100f;

        private readonly List<Combatant> _combatants;
        private readonly ICombatAI _ai;
        private readonly IActionResolver _resolver;

        public CombatSystem(
            IEnumerable<Character> characters,
            ICombatAI ai,
            IActionResolver resolver)
        {
            _combatants = characters.Select(c => new Combatant(c)).ToList();
            _ai = ai;
            _resolver = resolver;
        }

        public void Start()
        {
            Console.WriteLine("=== COMBATE ===");

            while (_combatants.Count(c => c.IsAlive) > 1)
            {
                foreach (var actor in _combatants.Where(c => c.IsAlive))
                {
                    actor.AddInitiative();

                    if (!actor.CanAct(TURN_THRESHOLD))
                        continue;

                    actor.ResetTurnState();

                    var enemies = _combatants.Where(c => c != actor && c.IsAlive);

                    var action = _ai.DecideAction(actor, enemies);

                    _resolver.Resolve(action, actor, enemies);

                    actor.ConsumeTurn(TURN_THRESHOLD);
                }
            }

            var winner = _combatants.FirstOrDefault(c => c.IsAlive);
            Console.WriteLine($"\n🏆 Ganador: {winner?.Character.Name}");
        }
    }
}
