using System.Collections.Generic;

namespace Code.Inventories.Slots.SlotStrategy {
    public interface ISlotCreator {
        
        public List<ItemSlot> GenerateItemSlots();
    }
}