using Code.Inventories.Slots;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.GUI.Interactable {
    public class ItemSlotController : MonoBehaviour {
        private Vector2 relativeSlotPos;
        public ItemSlot Slot;

        [FormerlySerializedAs("currentObject")]
        public DraggableItemController draggableItemController;

        // public void AssignItem(DraggableItemController newObject) {
        //     //check if the slot can be assigned the new object type
        //     draggableItemController = newObject;
        //     SetDraggableParent();
        //     draggableItemController.SetStartPos(transform.position);
        // }

        private void SetDraggableItem(DraggableItemController newDraggable) {
            draggableItemController = newDraggable;
            if (draggableItemController != null) {
                SetDraggableParent();
                draggableItemController.SetStartPos(transform.position);
            }
        }

        private void SetDraggableParent() {
            draggableItemController.transform.SetParent(gameObject.transform);
        }

        //handles swapping of items/assignment from one slot to another
        public bool Assign(ItemSlotController provider) {
            if (Slot.IsValidItem(provider.Slot.CurrentItem)) {//if new item is valid for this slot
                var receiverItem = Slot.CurrentItem;
                var receiverDraggable = draggableItemController;
                if (provider.Slot.IsValidItem(Slot.CurrentItem)) { //if this slot's items are valid for provider slot - swap
                    //this
                    Slot.ChangeCurrentItem(provider.Slot.CurrentItem);
                    SetDraggableItem(provider.draggableItemController);
                    //other
                    provider.Slot.ChangeCurrentItem(receiverItem);
                    provider.SetDraggableItem(receiverDraggable);
                    if (provider.Slot.CurrentItem != null) {
                        provider.draggableItemController.MoveToDefaultPos();
                    }
                    
                    return true;
                }
            }

            return false;
        }
    }
}