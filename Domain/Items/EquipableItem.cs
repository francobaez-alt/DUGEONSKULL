using System;
using Domain.Characters;

namespace Domain.Items
{
    public enum EquipmentSlot
    {
        Helmet,
        Chest,
        Gloves,
        Boots,
        Weapon,
        Ring,
        Amulet
    }
    public abstract class EquipableItem : Item
    {
        public EquipmentSlot Slot { get;}
        
        protected EquipableItem(
            string name, 
            EquipmentSlot slot, 
            Stats bonusStats   ) : base(name, bonusStats)
        {
            Slot = slot;
        }
    }
}
