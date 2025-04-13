using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Common
{
    public class InputHandler : IUpdateReceiver
    {
        public int Priority => 0;

        [Inject] private UpdateHandler _updateHandler;

        private List<(InputAction actionButton, Input playerInput)> _actions = new();
        private List<(InputAction moveButton, Input)> _moves = new();

        public InputHandler(UpdateHandler updateHandler)
        {
            _updateHandler = updateHandler;
            _updateHandler.Register(this);

            var inputActions = new PlayerInputActions();
            inputActions.Enable();

            _actions.Add((inputActions.PlayerActionMap.Action_P1, Input.PlayerInputs[0]));
            _actions.Add((inputActions.PlayerActionMap.Action_P2, Input.PlayerInputs[1]));

            _moves.Add((inputActions.PlayerActionMap.Move_P1, Input.PlayerInputs[0]));
            _moves.Add((inputActions.PlayerActionMap.Move_P2, Input.PlayerInputs[1]));
        }

        public void Tick(float delta)
        {
            foreach (var (actionButton, playerInput) in _actions)
            {
                playerInput.IsActionPressed = actionButton.WasPressedThisFrame();
            }

            foreach (var (moveButton, playerInput) in _moves)
            {
                playerInput.MoveDirection = moveButton.ReadValue<Vector2Int>();
            }
        }
    }
}