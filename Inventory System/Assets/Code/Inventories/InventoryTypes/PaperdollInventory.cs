using Code.Inventories.Slots.SlotStrategy;

namespace Code.Inventories.InventoryTypes {
    public class PaperdollInventory : Inventories.Inventory {
        public PaperdollInventory(ISlotCreator slotCreatorStrategy) : base(slotCreatorStrategy) {
        }
    }
}