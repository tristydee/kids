using Common;
using Zenject;

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
            //do some random stuff here.
        }
    }
}