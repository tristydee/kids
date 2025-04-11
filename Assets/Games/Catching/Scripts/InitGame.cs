using Common;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Catching
{
    public class InitGame : MonoInstaller
    {
        [SerializeField] private UpdateHandler _updateHandler;
        
        public override void InstallBindings()
        {
            Container.Bind<UpdateHandler>().FromInstance(_updateHandler).AsSingle();
        }

        private void Start()
        {
            Player p1 = new Player();
            Container.Inject(p1);
            Player p2 = new Player();
            Container.Inject(p2);
            p1.Init();
            p2.Init();
            Container.Inject(p2);

            Insect insect = new Insect();
            Container.Inject(insect);
            insect.Init();
        }
    }
    
    
}