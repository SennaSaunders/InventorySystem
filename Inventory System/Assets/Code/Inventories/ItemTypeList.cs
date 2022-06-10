using System;
using System.Collections.Generic;
using Code.Items;

namespace Code.Inventories {
    public class ItemTypeList {
        public ItemTypeList() { }
        public ItemTypeList(List<Type> itemTypes) {
            AddMany(itemTypes);
        }

        public List<Type> ItemTypes = new List<Type>();

        public void Add(Type type) {
            //if not already in the list
            if (!ItemTypes.Contains(type)&& type.IsSubclassOf(typeof(Item))) {
                ItemTypes.Add(type);
            }
        }

        public void AddMany(List<Type> types) {
            foreach (Type type in types) {
                Add(type);
            }
        }

        public void Remove(Type type) {
            ItemTypes.Remove(type);
        }

        public bool Contains(Type type) {
            return ItemTypes.Contains(type);
        }
    }
}