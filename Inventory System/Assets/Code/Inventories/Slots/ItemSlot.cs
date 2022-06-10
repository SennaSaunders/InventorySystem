using Code.Items;
using UnityEngine;

namespace Code.Inventories.Slots {
    public class ItemSlot {
        public ItemSlot(ItemTypeList itemTypes, Vector2 slotPos) {
            ItemTypes = itemTypes;
            SlotPos = slotPos;
        }

        public ItemTypeList ItemTypes;
        public Vector2 SlotPos;
        public Item CurrentItem { get; private set; }


        public bool ChangeCurrentItem(Item newItem) {
            if (IsValidItem(newItem) || newItem == null) {
                CurrentItem = newItem;
                return true;
            }

            return false;
        }

        public bool IsValidItem(Item newItem) {
            if (newItem == null) {
                return true;
            }

            return ItemTypes.Contains(newItem.GetType()) || ItemTypes.ItemTypes.Exists(item => newItem.GetType().IsSubclassOf(item));
        }
    }
}