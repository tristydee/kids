using Common;
using UnityEngine;
using Zenject;
using Input = Common.Input;

namespace Catching
{
    public class RandomAI : IUpdateReceiver
    {
        [Inject] private UpdateHandler _updateHandler;

        public int Priority => 0;
        
        private Input _input;

        public void Init(Input input)
        {
            _input = input;
            _updateHandler.Register(this);
        }
        
        public void Tick(float delta)
        {
            var x = Random.Range(0, 2);
            if (x == 0)
                x = -1;
            
            var y = Random.Range(0, 2);
            if (y == 0)
                y = -1;

            if (Random.value > .5f)
            {
                x = 0;
            }
            else
            {
                y = 0;
            }
            
            _input.MoveDirection = new Vector2Int(x,y);
            
        }
    }
}