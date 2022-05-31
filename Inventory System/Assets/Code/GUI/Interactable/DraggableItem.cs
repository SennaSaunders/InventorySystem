using System.Collections.Generic;
using Code.GUI.Utility;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.GUI.Interactable {
    public class DraggableItem : MonoBehaviour, IDragHandler, IEndDragHandler {
        private Vector3 defaultPos;
        private Vector2 size;

        private void Awake() {
            gameObject.layer = LayerMask.NameToLayer("GUIItem");
            SetStartPos(transform.position);
            SetSize();
        }

        private void SetSize() {
            size = GetComponent<RectTransform>().sizeDelta;
        }

        public void SetStartPos(Vector3 position) {
            defaultPos = position;
        }

        public void MoveDefaultPos() {
            transform.position = defaultPos;
        }

        public void OnDrag(PointerEventData eventData) {
            Vector2 offset = new Vector2(-size.x, size.y);
            transform.position = eventData.position;
            BringToFront();
        }

        private void BringToFront() {
            GameObjectHelper.FindParentWithComponent<ItemSlot>(gameObject).transform.parent.transform.parent.SetAsLastSibling();
        }

        public void OnEndDrag(PointerEventData eventData) {
            ItemSlot newSlot = GetHoveredInventorySlot(eventData);
            if (newSlot != null) {
                if (newSlot.currentObject != this) {
                    ItemSlot oldSlot = GetCurrentGUISlot();
                    if (newSlot.currentObject != null) { //object already in the slot
                        oldSlot.AssignItem(newSlot.currentObject);
                        oldSlot.currentObject.MoveDefaultPos();
                    }
                    else {
                        oldSlot.currentObject = null;
                    }

                    newSlot.AssignItem(this);
                }
            }
            MoveDefaultPos();
        }

        private ItemSlot GetCurrentGUISlot() {
            return GameObjectHelper.FindParentWithComponent<ItemSlot>(gameObject).GetComponent<ItemSlot>();
        }

        private ItemSlot GetHoveredInventorySlot(PointerEventData eventData) {
            List<RaycastResult> test = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, test);
            ItemSlot hoveredSlot = null;
            for (int i = 0; i < test.Count; i++) {
                RaycastResult raycastResult = test[i];
                hoveredSlot = raycastResult.gameObject.GetComponent<ItemSlot>();
                if (hoveredSlot) return hoveredSlot;
            }

            return hoveredSlot;
        }
    }
}