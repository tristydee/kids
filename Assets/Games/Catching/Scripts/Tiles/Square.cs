using System;
using UnityEngine;

namespace Catching
{
    public class Square
    {
        protected Vector2Int Position;
        protected SquareView View;
        protected SquareDict Squares;

        public void Init(Vector2Int position, SquareView view, SquareDict squares)
        {
            Position = position;
            View = view;
            Squares = squares;
            SetPosition(position);
            SetView(view);
        }

        public void SetPosition(Vector2Int newPos)
        {
            Squares[Position] = null;
            Squares[newPos] = this;
            Position = newPos;
            View.MoveTo(newPos);
        }

        public void SetView(SquareView view)
        {
            View = view;
        }

        public virtual void Catch(Player player)
        {
            
        }
    }
}