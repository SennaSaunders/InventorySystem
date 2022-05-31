using UnityEngine;

namespace Code.GUI.Interactable {
    public class ItemSlot : MonoBehaviour {
        public DraggableItem currentObject;

        private void Awake() {
            gameObject.layer = LayerMask.NameToLayer("InventorySlot");
        }

        public void AssignItem(DraggableItem newObject) {
            currentObject = newObject;
            SetDraggableParent();
            currentObject.SetStartPos(transform.position);
        }

        private void SetDraggableParent() {
            currentObject.transform.SetParent(gameObject.transform);
        }
    }
}