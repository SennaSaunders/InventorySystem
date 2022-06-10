using System;
using System.Collections.Generic;
using Code.Inventories;
using Code.Inventories.InventoryTypes;
using Code.Items;
using Code.Items.Armour;
using Code.Items.Armour.Types.Helmet;
using Code.Items.Weapons;
using UnityEngine;
using Random = System.Random;

namespace Code.ItemGenerator {
    public class ShopGenerator : MonoBehaviour {
        private InventoryGUIController _inventoryGUIController;
        public float itemPercentage = .5f;
        private ItemTypeList ItemTypes = new ItemTypeList(new List<Type>() { typeof(Helmet), typeof(Weapon) });

        private void Awake() {
            GenerateShop();
        }

        public void GenerateShop() {
            SetInventoryController();
            SetupInventory();
            GenerateItems();
        }

        private void SetInventoryController() {
            _inventoryGUIController = gameObject.AddComponent<InventoryGUIController>();
        }

        private void SetupInventory() {
            _inventoryGUIController.Inventory = new StorageInventory(5, 8, new ItemTypeList(new List<Type>() { typeof(Weapon), typeof(Armour) }));
        }

        private void GenerateItems() {
            Inventory inventory = _inventoryGUIController.Inventory; 
            if ( inventory!= null) {
                int itemsToGenerate = (int)(inventory.ItemSlots.Count * itemPercentage);
                Random r = new Random();
                for (int i = 0; i < itemsToGenerate; i++) {
                    int typeIndex = r.Next(ItemTypes.ItemTypes.Count);
                    Item newItem = (Item)Activator.CreateInstance(ItemTypes.ItemTypes[typeIndex], ItemTypes.ItemTypes[typeIndex].Name, "asdasd");
                    _inventoryGUIController.Inventory.ItemSlots[i].ChangeCurrentItem(newItem);
                }

                _inventoryGUIController.DisplayInventory();
            }
        }
    }
}