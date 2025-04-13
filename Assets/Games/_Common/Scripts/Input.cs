using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class Input
    {
        public static List<Input> PlayerInputs = new(){new Input(), new Input()};

        public bool IsActionPressed {  get; set; }
        public bool IsMovePressed => MoveDirection != Vector2.zero;
        public Vector2Int MoveDirection { get; set; }
        
    }
}