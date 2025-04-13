using UnityEngine;

namespace Catching
{
    public class Square
    {
        protected Vector2Int Position;
        protected SquareView View;
        protected SquareDict Squares;
        
        public void SetPosition(Vector2Int tilePos)
        {
            Position = tilePos;
            Squares[Position] = this;
            Squares[tilePos] = null;
            View.MoveTo(tilePos);
        }

        public void SetView(SquareView view)
        {
            View = view;
        }
    }
}