using System;
using Domain.Items;

namespace Domain.Characters
{
    public class Inventory
    {
        private readonly List<Item> _items;
        public IReadOnlyList<Item> Items => _items.AsReadOnly();

        public int StorageCapacity { get; private set; }

        public bool IsFull => _items.Count >= StorageCapacity;
        public bool IsEmpty => _items.Count == 0;
        public int Count => _items.Count;

        public Inventory(int capacity = 20)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "La capacidad debe ser mayor a cero.");

            StorageCapacity = capacity;
            _items = new List<Item>(capacity);
        }

        public void Add(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (IsFull)
                throw new InvalidOperationException("El inventario está lleno.");

            _items.Add(item);
        }

        public void Remove(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (!_items.Remove(item))
                throw new InvalidOperationException("El item no se encuentra en el inventario.");
        }

        public Item GetItem(int index)
        {
            if (index < 0 || index >= _items.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            return _items[index];
        }

        public List<Item> Clear()
        {
            var backup = new List<Item>(_items);
            _items.Clear();
            return backup;
        }

        public void IncreaseCapacity(int amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "El incremento debe ser positivo.");

            StorageCapacity += amount;
        }

        public void DecreaseCapacity(int amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (StorageCapacity - amount < _items.Count)
                throw new InvalidOperationException("No se puede reducir la capacidad por debajo de los items actuales.");

            StorageCapacity -= amount;
        }

        public bool Contains(Item item) => _items.Contains(item);
    }
}
