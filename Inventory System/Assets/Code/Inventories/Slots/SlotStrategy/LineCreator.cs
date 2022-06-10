namespace Code.Inventories.Slots.SlotStrategy {
    public class LineCreator : GridCreator {
        public enum Orientation {
            Vertical,
            Horizontal
        }

        public LineCreator(int count, Orientation orientation, ItemTypeList itemTypes) : base(orientation==Orientation.Horizontal?(count,1):(1,count), itemTypes) { }

        private int slotCount;
        private Orientation _orientation;
        private readonly ItemTypeList  _itemTypes;
    }
}