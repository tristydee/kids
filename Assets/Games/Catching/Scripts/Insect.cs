using Common;
using UnityEngine;
using Zenject;

namespace Catching
{
    public class Insect : IUpdateReceiver
    {
        [Inject] private UpdateHandler _updateHandler;
        public int Priority => 2;

        public void Init()
        {
            _updateHandler.Register(this);
        }


        public void Tick(float delta)
        {
        }
    }
}