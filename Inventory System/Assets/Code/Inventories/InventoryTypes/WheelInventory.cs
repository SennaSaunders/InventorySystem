using Code.Inventories.Slots.SlotStrategy;

namespace Code.Inventories.InventoryTypes {
    public class WheelInventory : SelectionInventory{
        public WheelInventory(int count, ItemTypeList itemTypes) : base(new CircleCreator(count, itemTypes)) {
        }
    }
}