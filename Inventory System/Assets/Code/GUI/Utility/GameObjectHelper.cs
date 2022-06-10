using System;
using TMPro;
using UnityEngine;

namespace Code.GUI.Utility {
    public static class GameObjectHelper {
        public static GameObject FindChildByName(GameObject parent, string childName) {
            GameObject foundObject = null;
            for (int i = 0; i < parent.transform.childCount; i++) {
                GameObject child = parent.transform.GetChild(i).gameObject;
                foundObject = child.name == childName ? child : FindChildByName(child, childName);
                if (foundObject != null) break;
            }

            return foundObject;
        }

        private static GameObject RecursiveFindChild<T>(GameObject parent, Func<GameObject, T, bool> conditionFunc, T param) {
            GameObject foundObject = null;
            for (int i = 0; i < parent.transform.childCount; i++) {
                GameObject child = parent.transform.GetChild(i).gameObject;
                foundObject = (bool)conditionFunc.DynamicInvoke(child, param) ? child : RecursiveFindChild<T>(child, conditionFunc, param);
                if (foundObject != null) break;
            }

            return foundObject;
        }

        public static GameObject FindChildWithTag(GameObject parent, string tag) {
            return RecursiveFindChild(parent, HasTag, tag);
        }

        private static bool HasTag(GameObject gameObject, string tag) {
            bool hasTag =gameObject.CompareTag(tag);
            return hasTag;
        }

        public static GameObject FindParentWithComponent<T>(GameObject child) where T:MonoBehaviour {
            GameObject foundObject = null;
            if (child.transform.parent != null) {
                GameObject parentObject = child.transform.parent.gameObject;
                if (parentObject.GetComponentInParent<T>()) {
                    foundObject = parentObject;
                }
                else {
                    FindParentWithComponent<T>(parentObject);
                }
            }

            return foundObject;
        }
        
        
        
        public static GameObject FindParentByName(GameObject child, string parentName) {
            GameObject foundObject = null;
            if (child.transform.parent != null) {
                GameObject parentObject = child.transform.parent.gameObject;
                if (parentObject.name == parentName) {
                    foundObject = parentObject;
                }
                else {
                    FindParentByName(parentObject, parentName);
                }
            }

            return foundObject;
        }

        public static void BringToFront(GameObject gameObject) {
            gameObject.transform.SetAsLastSibling();
            if (gameObject.transform.parent != null) {
                BringToFront(gameObject.transform.parent.gameObject);
            }
        }

        public static void SetText(GameObject gameObject, string text) {
            TextMeshProUGUI textComponent = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            if (textComponent != null) {
                textComponent.text = text;
            }
        }
    }
}