using System;
using Catching.Tiles;
using Common;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;
using Input = Common.Input;

namespace Catching
{
    public class MovingSquare : Square, IUpdateReceiver
    {
        [Inject] private UpdateHandler _updateHandler;
        public int Priority => 1;
        
        public float MoveDelayInSeconds => .2f;

        protected SquareDict _groundSquares;
        protected SquareDict _objectSquares;

        protected Input _input;

        protected Vector2Int Direction;

        private float moveTimer;

        public void Init(Input input, SquareDict groundSquares, SquareDict objectSquares)
        {
            _input = input;
            _groundSquares = groundSquares;
            _objectSquares = objectSquares;
            _updateHandler.Register(this);
        }


        public virtual void Tick(float delta)
        {
            moveTimer += delta;
            
            if (_input.IsMovePressed)
            {
                if(moveTimer < MoveDelayInSeconds)
                    return;
                
                moveTimer = 0;
                
                var dir = _input.MoveDirection;

                if (dir.x != 0 && dir.y != 0)
                    dir.y = 0;

                if (dir != Direction)
                {
                    Turn(dir);
                    return;
                }

                Direction = dir;
                var newPos = Position + dir;
                if (_groundSquares.ContainsKey(newPos))
                {
                    if (_objectSquares.TryGetValue(newPos, out var obj))
                    {
                        if (obj == null)
                            Move(newPos);
                        else
                            Collide(obj, dir);
                    }
                    else
                    {
                        Move(newPos);
                    }
                }
            }
        }

        private void Turn(Vector2Int direction)
        {
            Direction = direction;
        }


        private void Move(Vector2Int newPos)
        {
            SetPosition(newPos);
        }

        private void Collide(Square tile, Vector2Int dir)
        {
            if (tile is MoveableSquare)
            {
            }
        }
    }
}