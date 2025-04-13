using UnityEngine;

namespace Catching
{
    public class SquareView : MonoBehaviour
    {
        [SerializeField] public SpriteRenderer spriteRenderer;
        public int Layer => spriteRenderer.sortingOrder;

        public void MoveTo(Vector2Int tilePos)
        {
            transform.position = new Vector3(tilePos.x, tilePos.y, 0);
        }
    }
}