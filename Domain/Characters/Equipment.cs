using System;
using Domain.Items;

namespace Domain.Characters
{
    public class Equipment
    {
        private readonly Dictionary<EquipmentSlot, EquipableItem> _equipped
            = new Dictionary<EquipmentSlot, EquipableItem> ();
        public IReadOnlyDictionary<EquipmentSlot, EquipableItem> EquippedItems
            => _equipped;
        public bool isSlotEmpty(EquipmentSlot slot) => !_equipped.ContainsKey (slot);
        public EquipableItem? GetItem(EquipmentSlot slot)
            => _equipped.TryGetValue(slot, out var item) ? item : null;

        public event Action<EquipableItem>? OnItemEquipped;
        public event Action<EquipableItem>? OnItemUnequipped;

        public void Equip(EquipableItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            // Si ya había algo equipado en ese slot
            if (_equipped.TryGetValue(item.Slot, out var oldItem))
            {
                _equipped.Remove(item.Slot);
                OnItemUnequipped?.Invoke(oldItem);
            }

            _equipped[item.Slot] = item;
            OnItemEquipped?.Invoke(item);
        }

        public EquipableItem Unequip(EquipmentSlot slot)
        {
            if (!_equipped.TryGetValue(slot, out var item))
                throw new InvalidOperationException($"No hay item equipado en {slot}");

            _equipped.Remove(slot);
            OnItemUnequipped?.Invoke(item);

            return item;
        }

        public IEnumerable<EquipableItem> GetAllEquipped()
            => _equipped.Values;
    }
}
