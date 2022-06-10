using Code.Inventories.Slots.SlotStrategy;

namespace Code.Inventories.InventoryTypes {
    public class SelectionInventory : Inventories.Inventory{
        protected SelectionInventory(ISlotCreator slotCreatorStrategy) : base(slotCreatorStrategy) {
        }
    }
}