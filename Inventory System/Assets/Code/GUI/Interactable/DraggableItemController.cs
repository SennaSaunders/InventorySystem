using System.Collections.Generic;
using Code.GUI.Utility;
using Code.Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.GUI.Interactable {
    public class DraggableItemController : MonoBehaviour, IDragHandler, IEndDragHandler {
        private Vector3 defaultPos;
        private Vector2 size;
        public Item item { get; set; }

        private void Awake() {
            SetStartPos(transform.position);
            SetSize();
        }

        private void SetSize() {
            size = GetComponent<RectTransform>().sizeDelta;
        }

        public void SetStartPos(Vector3 position) {
            defaultPos = position;
        }

        public void MoveToDefaultPos() {
            transform.position = defaultPos;
        }

        public void OnDrag(PointerEventData eventData) {
            transform.position = eventData.position;
            BringToFront();
        }

        private void BringToFront() {
            GameObjectHelper.BringToFront(gameObject);
        }

        public void OnEndDrag(PointerEventData eventData) {
            ItemSlotController receiver = GetHoveredInventorySlot(eventData);
            if (receiver != null) {
                if (receiver.draggableItemController != this) {
                    // Item previousItem = newSlotController.Slot.CurrentItem;
                    ItemSlotController provider = GetCurrentGUISlot();
                    if (provider != null) {
                        receiver.Assign(provider);
                    }
                    // if (newSlotController.Slot.IsValidItem(oldSlotController.Slot.CurrentItem) && oldSlotController.Slot.IsValidItem(newSlotController.Slot.CurrentItem)) {
                    //     if (newSlotController.draggableItemController != null) { //if an object is already in the slot - why do this here? do this in the item slot controller and pass it the other slot
                    //         newSlotController.Slot.ChangeCurrentItem(oldSlotController.Slot.CurrentItem);
                    //         oldSlotController.Slot.ChangeCurrentItem(previousItem);//move the item
                    //         oldSlotController.AssignItem(newSlotController.draggableItemController);
                    //         oldSlotController.draggableItemController.MoveDefaultPos();
                    //     }
                    //     else {
                    //         oldSlotController.draggableItemController = null;
                    //     }
                    //
                    //     newSlotController.AssignItem(this);
                    // }
                }
            }
            MoveToDefaultPos();
        }

        private ItemSlotController GetCurrentGUISlot() {
            return GameObjectHelper.FindParentWithComponent<ItemSlotController>(gameObject).GetComponent<ItemSlotController>();
        }

        private ItemSlotController GetHoveredInventorySlot(PointerEventData eventData) {
            List<RaycastResult> test = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, test);
            ItemSlotController hoveredSlotController = null;
            for (int i = 0; i < test.Count; i++) {
                RaycastResult raycastResult = test[i];
                hoveredSlotController = raycastResult.gameObject.GetComponent<ItemSlotController>();
                if (hoveredSlotController) return hoveredSlotController;
            }

            return hoveredSlotController;
        }
    }
}