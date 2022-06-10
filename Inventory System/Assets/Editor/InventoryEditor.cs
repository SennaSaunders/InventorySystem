using System;
using System.Linq;
using Code.Inventories;
using Code.Inventories.InventoryTypes;
using Code.Inventories.Slots.SlotStrategy;
using Code.Inventories.Slots.SlotStrategy.Paperdoll;
using UnityEditor;
using UnityEngine;

namespace Editor {
    [CustomEditor(typeof(InventoryGUIController))]
    public class InventoryEditor : UnityEditor.Editor {
        private InventoryGUIController _inventoryGUIController;
        private int _selectedInventoryType;
        private int _x = 5;
        private int _y = 6;
        private int _count = 10;
        private int _selectedOrientation;
        private readonly LineCreator.Orientation[] _orientations = { LineCreator.Orientation.Horizontal, LineCreator.Orientation.Vertical };

        private readonly Type[] _paperdollTypes = { typeof(BasicPaperdoll) };
        private int _selectedPaperdollType;

        public override void OnInspectorGUI() {
            _inventoryGUIController = (InventoryGUIController)target;
            Vector2 tempDistanceScale = _inventoryGUIController.distanceScale;
            
            InventoryTypeCustomisation();
            DrawDefaultInspector();
            
            if (tempDistanceScale != _inventoryGUIController.distanceScale) {
                RefreshInventory();
            }
        }

        private void InventoryTypeCustomisation() {
            Type[] inventoryTypes = { typeof(StorageInventory), typeof(HotbarInventory), typeof(WheelInventory), typeof(PaperdollInventory) };
            string[] names = { };
            foreach (Type inventoryType in inventoryTypes) {
                names = names.Append(inventoryType.Name).ToArray();
            }

            int tempInventoryType = _selectedInventoryType;
            _selectedInventoryType = EditorGUILayout.Popup("InventoryType", _selectedInventoryType, names);
            
            switch (_selectedInventoryType) {
                case 0:
                    StorageCustomisation();
                    break;
                case 1:
                    HotbarCustomisation();
                    break;
                case 2:
                    WheelCustomisation();
                    break;
                case 3:
                    PaperdollCustomisation();
                    break;
            }

            if (tempInventoryType != _selectedInventoryType) {
                RefreshInventory();
            }
        }

        private void StorageCustomisation() {
            int temp = _x;
            _x = EditorGUILayout.IntSlider("Width",_x, 1, 10);
            if (_x != temp) {
                RefreshInventory();
            }

            temp = _y;
            _y = EditorGUILayout.IntSlider("Height",_y, 1, 10);
            if (_y != temp) {
                RefreshInventory();
            }
        }

        private void HotbarCustomisation() {
            int temp = _count;
            _count = EditorGUILayout.IntSlider("Count",_count, 1, 10);
            if (temp != _count) {
                RefreshInventory();
            }
                    
            string[] orientationNames = { };
            foreach (LineCreator.Orientation orientation in _orientations) {
                orientationNames = orientationNames.Append(orientation.ToString()).ToArray();
            }

            int tempOrientation = _selectedOrientation;
            _selectedOrientation = EditorGUILayout.Popup("Orientation", _selectedOrientation, orientationNames);
            if (tempOrientation != _selectedOrientation) {
                RefreshInventory();
            }
        }
        private void WheelCustomisation() {
            int temp = _count;
            _count = EditorGUILayout.IntSlider("Count",_count, 2, 18);
            if (temp != _count) {
                RefreshInventory();
            }
        }
        private void PaperdollCustomisation() {
            string[] paperdollTypeNames = { };
            foreach (Type type in _paperdollTypes) {
                paperdollTypeNames = paperdollTypeNames.Append(type.Name).ToArray();
            }

            _selectedPaperdollType = EditorGUILayout.Popup("Paperdoll Strategy", _selectedPaperdollType, paperdollTypeNames);
        }

        private void RefreshInventory() {
            _inventoryGUIController.ClearInventory();
            switch (_selectedInventoryType) {
                case 0:
                    _inventoryGUIController.Inventory = new StorageInventory(_x, _y, new ItemTypeList());
                    break;
                case 1:
                    _inventoryGUIController.Inventory = new HotbarInventory(_count, _orientations[_selectedOrientation], new ItemTypeList());
                    break;
                case 2:
                    _inventoryGUIController.Inventory = new WheelInventory(_count, new ItemTypeList());
                    break;
                case 3:
                    _inventoryGUIController.Inventory = new PaperdollInventory((ISlotCreator)Activator.CreateInstance(_paperdollTypes[_selectedPaperdollType]));
                    break;
            }
            _inventoryGUIController.DisplayInventory();
        }
    }
}