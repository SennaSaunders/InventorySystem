using Code.GUI.Interactable;
using Code.GUI.Utility;
using Code.Inventories.Slots;
using UnityEngine;

namespace Code.Inventories {
    public class InventoryGUIController : MonoBehaviour {
        public Inventory Inventory;
        public Vector2 distanceScale = new Vector2(1, 1);
        private string basePath = "Prefabs/";
        private string slotPrefabPath = "ItemSlot";
        private string itemPrefabPath = "Item";

        public void DisplayInventory() {
            if (Inventory != null) {
                GameObject itemSlotPrefab = (GameObject)Resources.Load(basePath + slotPrefabPath);
                Vector2 itemSlotObjectSize = itemSlotPrefab.GetComponent<RectTransform>().sizeDelta;
                foreach (ItemSlot itemSlot in Inventory.ItemSlots) {
                    GameObject itemSlotObject = Instantiate(itemSlotPrefab, gameObject.transform);
                    itemSlotObject.transform.localPosition = itemSlot.SlotPos * itemSlotObjectSize * distanceScale;
                    GameObject itemWindow = GameObjectHelper.FindChildWithTag(itemSlotObject, "ItemWindow");
                    ItemSlotController itemSlotController = itemWindow.AddComponent<ItemSlotController>();
                    itemSlotController.Slot = itemSlot;
                    if (itemSlot.CurrentItem != null) {
                        DisplayItem(itemWindow, itemSlotController);
                    }
                }
            }
        }

        private void DisplayItem(GameObject itemWindow, ItemSlotController itemSlotController) {
            GameObject itemObject = (GameObject)Instantiate(Resources.Load(basePath + itemPrefabPath), itemWindow.transform);
            DraggableItemController draggableItemController = itemObject.AddComponent<DraggableItemController>();
            draggableItemController.item = itemSlotController.Slot.CurrentItem;
            itemSlotController.draggableItemController = draggableItemController;
            GameObjectHelper.SetText(itemObject, itemSlotController.Slot.CurrentItem.ItemName);
        }

        public void ClearInventory() {
            for (int i = gameObject.transform.childCount - 1; i >= 0; i--) {
                DestroyImmediate(gameObject.transform.GetChild(i).gameObject);
            }
        }
    }
}