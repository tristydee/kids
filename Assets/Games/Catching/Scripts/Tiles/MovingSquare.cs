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

        private SquareDict _groundSquares;
        private SquareDict _objectSquares;

        protected Input _input;

        private Vector2Int _direction;

        public void Init(Input input, SquareDict groundSquares, SquareDict objectSquares)
        {
            _input = input;
            _groundSquares = groundSquares;
            _objectSquares = objectSquares;
            _updateHandler.Register(this);
        }


        public virtual void Tick(float delta)
        {
            if (_input.IsMovePressed)
            {
                var dir = _input.MoveDirection;

                if (dir != _direction)
                {
                    Turn(dir);
                    return;
                }
                
                _direction = dir;
                var newPos = Position + dir;
                if (_groundSquares.ContainsKey(newPos))
                {
                    var obj = _objectSquares[newPos];
                    if (obj == null)
                        Move(newPos);
                    else
                        Collide(obj, dir);
                }
                
            }
        }

        private void Turn(Vector2Int direction)
        {
            _direction = direction;
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