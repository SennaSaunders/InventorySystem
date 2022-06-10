using Code.ItemGenerator;
using UnityEditor;
using UnityEngine;

namespace Editor {
    [CustomEditor(typeof(ShopGenerator))]
    public class ShopEditor :UnityEditor.Editor {
        private ShopGenerator _shopGenerator; 
        public override void OnInspectorGUI() {
            _shopGenerator = (ShopGenerator)target;
            if (GUILayout.Button("Generate Shop Items")) {
                _shopGenerator.GenerateShop();
            }
        }
    }
}