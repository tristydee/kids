using System.Linq;
using Common;
using Games.Catching.Scripts.Tiles;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Catching
{
    public class InitGame : MonoInstaller
    {
        [SerializeField] private UpdateHandler _updateHandler;

        private SquareDict groundSquares = new SquareDict();
        private SquareDict objectSquares = new SquareDict();

        public override void InstallBindings()
        {
            Container.Bind<UpdateHandler>().FromInstance(_updateHandler).AsSingle();
            Container.Bind<InputHandler>().AsSingle();
        }

        public override void Start()
        {
            CreateGridFromViews();
            
            var players = objectSquares.GetSquaresOfType<Player>().ToList();
            
            Player p1 = players[0];
            Player p2 = players[1];
            MovingSquare insect = objectSquares.GetSquaresOfType<MovingSquare>().First();

            Container.Inject(p1);
            Container.Inject(p2);
            Container.Inject(insect);

            p1.Init(Common.Input.PlayerInputs[0], groundSquares, objectSquares);
            p2.Init(Common.Input.PlayerInputs[1], groundSquares, objectSquares);

            var ai = new RandomAI();
            Container.Inject(ai);
            var aiInput = new Common.Input();
            ai.Init(aiInput);
            insect.Init(aiInput, groundSquares, objectSquares);
        }

        private void CreateGridFromViews()
        {
            var squareViews = FindObjectsByType<SquareView>(FindObjectsInactive.Exclude, FindObjectsSortMode.None)
                .ToList();
            for (int i = 0; i < squareViews.Count; i++)
            {
                var view = squareViews[i];
                var pos = new Vector2Int((int)view.transform.position.x, (int)view.transform.position.y);
                var square = SquareFactory.CreateSquare(view);
                var map = view.Layer == 0 ? groundSquares : objectSquares;
                map[pos] = square;
                square.SetPosition(pos);
                square.SetView(view);
            }
        }
        
        
    }
}

