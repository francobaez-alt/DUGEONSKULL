using System;
using Domain.Characters;

namespace Domain.Items
{
    public class Chest : EquipableItem
    {
        public Chest(string name, Stats stats)
            : base(name, EquipmentSlot.Chest, stats)
        {

        }
    }
}
