using System.Collections.Generic;
using UnityEngine;

namespace Code.Inventories.Slots.SlotStrategy {
    public class GridCreator : IPosSlotCreator {//think about adding wrapping/sequential as complex types of grids
        public GridCreator((int x, int y) size, ItemTypeList itemTypes) {
            _gridSize = size;
            _itemTypes = itemTypes;
        }
        
        private (int x, int y) _gridSize;
        private readonly ItemTypeList _itemTypes;

        public List<Vector2> GeneratePositions() {
            List<Vector2> positions = new List<Vector2>();
            for (int i = 0; i < _gridSize.x; i++) {
                for (int j = 0; j < _gridSize.y; j++) {
                    float x = (-(float)_gridSize.x / 2) + (i*1) + .5f;
                    float y = (-(float)_gridSize.y / 2) + (j*1) + .5f;
                    
                    positions.Add(new Vector2(x,y));
                }
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