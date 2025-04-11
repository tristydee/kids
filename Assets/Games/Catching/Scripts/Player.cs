using Common;
using Zenject;

namespace Catching
{
    public class Player : IUpdateReceiver
    {
        [Inject] private UpdateHandler _updateHandler;
        public int Priority => 1;

        [Inject]
        public void Init()
        {
            _updateHandler.Register(this);
        }


        public void Tick(float delta)
        {
        }

        
    }
}