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
    }
}