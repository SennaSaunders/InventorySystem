using System.Collections.Generic;
using Code.Inventories.Slots;
using Code.Inventories.Slots.SlotStrategy;

namespace Code.Inventories {
    public abstract class Inventory {
        //list of SlotDisplay, display position(relative pos?)
        public List<ItemSlot> ItemSlots;

        protected Inventory(ISlotCreator slotCreatorStrategy) {
            ItemSlots = slotCreatorStrategy.GenerateItemSlots();
        }
    }
}