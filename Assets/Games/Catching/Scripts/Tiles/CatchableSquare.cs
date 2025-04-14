using Catching;
using UnityEngine;

namespace Games.Catching.Scripts.Tiles
{
    public class CatchableSquare : MovingSquare
    {
        public override void Catch(Player player)
        {
            Debug.Log("you won!");
        }
    }
}