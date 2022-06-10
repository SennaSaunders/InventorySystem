using System;
using System.Collections.Generic;
using Code.Items.Armour.Types.Boots;
using Code.Items.Armour.Types.Chest;
using Code.Items.Armour.Types.Helmet;
using Code.Items.Weapons;
using UnityEngine;

namespace Code.Inventories.Slots.SlotStrategy.Paperdoll {
    public class BasicPaperdoll : ISlotCreator {
        private readonly ItemTypeList _itemTypes = new ItemTypeList(new List<Type>() { typeof(Helmet),typeof(ChestPiece), typeof(Boots), typeof(Weapon)});
        //helmet, chest, boots, weapon
        public List<ItemSlot> GenerateItemSlots() {
            ItemTypeList head = new ItemTypeList(new List<Type>() { typeof(Helmet) });
            ItemTypeList chest = new ItemTypeList(new List<Type>() { typeof(ChestPiece) });
            ItemTypeList boots = new ItemTypeList(new List<Type>() { typeof(Boots) });
            ItemTypeList weapon = new ItemTypeList(new List<Type>() { typeof(Weapon) });
            
            return new List<ItemSlot>() {
                new ItemSlot(head, new Vector2(0, 1)),
                new ItemSlot(chest, new Vector2(0,0)),
                new ItemSlot(boots, new Vector2(0,-1)),
                new ItemSlot(weapon, new Vector2(1,0))
            };
        }
    }
}