using System.Collections.Generic;
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
            var inputHandler = new InputHandler();
            Container.Inject(inputHandler);
            inputHandler.Init();
            var players = objectSquares.GetSquaresOfType<Player>().ToList();

            for (var i = 0; i < players.Count; i++)
            {
                var player = players[i];
                Container.Inject(player);
                player.Init(Common.Input.PlayerInputs[i], groundSquares, objectSquares);
            }

            var insects = objectSquares.GetSquaresOfType<CatchableSquare>().ToList();
            for (var i = 0; i < insects.Count; i++)
            {
                var insect = insects[i];
                Container.Inject(insect);
                var ai = new RandomAI();
                Container.Inject(ai);
                var aiInput = new Common.Input();
                ai.Init(aiInput);
                insect.Init(aiInput, groundSquares, objectSquares);
            }
            
            
        }

        private void CreateGridFromViews()
        {
            var squareViews = FindObjectsByType<SquareView>(FindObjectsInactive.Exclude, FindObjectsSortMode.None)
                .ToList();
            foreach (var view in squareViews)
            {
                var pos = new Vector2Int((int)view.transform.position.x, (int)view.transform.position.y);
                var square = SquareFactory.CreateSquare(view);
                var map = view.Layer == 0 ? groundSquares : objectSquares;
                square.Init(pos, view, map);
            }
        }
    }
}