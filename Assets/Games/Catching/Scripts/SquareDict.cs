using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Catching
{
    public class SquareDict : Dictionary<Vector2Int, Square>
    {
        public IEnumerable<T> GetSquaresOfType<T>() where T: Square
        {
            return Values.Where(square => square.GetType() == typeof(T)).Select(s => (T)s);
        }
        
        // public TileDict(Tilemap map)
        // {
        //     for (int x = 0; x < map.size.x; x++)
        //     {
        //         for (int y = 0; y < map.size.y; y++)
        //         {
        //             var pos = new Vector2Int(x, y);
        //             var tile = map.GetTile(new Vector3Int(x, y, 0));
        //             Add(pos, tile);
        //         }
        //     }
        // }
    }
}