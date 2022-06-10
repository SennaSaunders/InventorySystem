namespace Code.Items {
    public abstract class Item {
        protected Item(string itemName, string itemIconPath) {
            ItemName = itemName;
            ItemIconPath = itemIconPath;
        }

        public string ItemName;
        public string SubTypePath;
        private static string BasePath = "";
        public string ItemIconPath;

        public string GetIconPath() {
            return BasePath + SubTypePath + ItemIconPath;
        }
    }
}