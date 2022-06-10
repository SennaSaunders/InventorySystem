using Code.Inventories.Slots.SlotStrategy;

namespace Code.Inventories.InventoryTypes {
    public class StorageInventory : Inventories.Inventory {
        public StorageInventory(int width, int height, ItemTypeList itemTypes) : base(new GridCreator((width, height), itemTypes)) {
        }
    }
}