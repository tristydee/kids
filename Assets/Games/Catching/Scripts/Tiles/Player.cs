using System;
using System.Data.SqlTypes;
using UnityEngine;

namespace Catching
{
    [Serializable]
    public class Player : MovingSquare
    {
        private float Delay => .2f;
        private float timer;

        public override void Tick(float delta)
        {
            timer += delta;
            base.Tick(delta);

            if (_input.IsActionPressed && timer > Delay)
            {
                timer = 0;
                var destination = Position + Direction;
                if (_objectSquares.TryGetValue(destination, out var obj))
                {
                    if(obj != null)
                        obj.Catch(this);
                }
                
                
            }
        }
    }
}