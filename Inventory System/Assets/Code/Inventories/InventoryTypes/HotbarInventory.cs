using Code.Inventories.Slots.SlotStrategy;

namespace Code.Inventories.InventoryTypes {
    public class HotbarInventory : SelectionInventory {
        public HotbarInventory(int size, LineCreator.Orientation orientation, ItemTypeList itemTypes) : base(new LineCreator(size, orientation, itemTypes)) {
        }
    }
}