using System;
using Domain.Characters;

namespace Domain.Items
{
    public class Weapon : EquipableItem
    {
        public Weapon (string name, Stats stats) 
            : base(name, EquipmentSlot.Weapon, stats)
        {

        }

    }
}
