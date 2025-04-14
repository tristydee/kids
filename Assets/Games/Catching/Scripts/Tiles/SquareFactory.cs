using System;
using System.Collections.Generic;
using Catching;
using Catching.Tiles;

namespace Games.Catching.Scripts.Tiles
{
    public class SquareFactory
    {
        
        private static Dictionary<Type, Type> _squares = new()
        {
            {typeof(BlockingView), typeof(BlockingSquare)},
            {typeof(InsectView), typeof(CatchableSquare)},
            {typeof(PlayerView), typeof(Player)},
            {typeof(GroundSquareView), typeof(NormalSquare)}
            
        };
        
        public static Square CreateSquare(SquareView view)
        {
            var square = _squares[view.GetType()];
            return (Square)Activator.CreateInstance(square);
        } 
    }
}