using System;
using Domain.Characters;

namespace Domain.Progression
{
    public interface IClassProgression
    {
        Stats GetBaseStats();
        Stats GetLevelBonus(int newLevel);
        
    }
}
