using System.Collections.Generic;
using UnityEngine;

namespace Code.Inventories.Slots.SlotStrategy {
    public class CircleCreator : IPosSlotCreator {//think about semi circles/half arcs/starting position
        public CircleCreator(int count, ItemTypeList itemTypes) {
            slotCount = count;
            _itemTypes = itemTypes;
        }
        
        private int slotCount;
        private readonly ItemTypeList _itemTypes;

        public List<Vector2> GeneratePositions() {
            List<Vector2> positions = new List<Vector2>();
            float angle = (float)360 / slotCount;
            for (int i = 0; i < slotCount; i++) {
                Vector2 up = Vector2.up;//starting angle??
                Vector2 position = Quaternion.Euler(0, 0, angle * i) * up;
                positions.Add(position);
            }

            return positions;
        }

        public List<ItemSlot> GenerateItemSlots() {
            var positions = GeneratePositions();
            List<ItemSlot> itemSlots = new List<ItemSlot>();
            foreach (Vector2 position in positions) {
                itemSlots.Add(new ItemSlot(_itemTypes, position));
            }

            return itemSlots;
        }
    }
}