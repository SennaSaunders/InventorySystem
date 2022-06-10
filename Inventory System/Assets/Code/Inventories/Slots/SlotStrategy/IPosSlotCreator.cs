using System.Collections.Generic;
using UnityEngine;

namespace Code.Inventories.Slots.SlotStrategy {
    public interface IPosSlotCreator : ISlotCreator{
        List<Vector2> GeneratePositions();
    }
}