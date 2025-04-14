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
        private List<(InputAction moveButton, Input)> _moveHorizontal = new();
        private List<(InputAction moveButton, Input)> _moveVertical = new();

        public void Init()
        {
            _updateHandler.Register(this);

            var inputActions = new PlayerInputActions();
            inputActions.Enable();

            _actions.Add((inputActions.PlayerActionMap.Action_P1, Input.PlayerInputs[0]));
            _actions.Add((inputActions.PlayerActionMap.Action_P2, Input.PlayerInputs[1]));

            _moveHorizontal.Add((inputActions.PlayerActionMap.Move_Horizontal_P1, Input.PlayerInputs[0]));
            _moveHorizontal.Add((inputActions.PlayerActionMap.Move_Horizontal_P2, Input.PlayerInputs[1]));

            _moveVertical.Add((inputActions.PlayerActionMap.Move_Vertical_P1, Input.PlayerInputs[0]));
            _moveVertical.Add((inputActions.PlayerActionMap.Move_Vertical_P2, Input.PlayerInputs[1]));
        }

        public void Tick(float delta)
        {
            foreach (var (actionButton, playerInput) in _actions)
            {
                playerInput.IsActionPressed = actionButton.WasPressedThisFrame();
            }


            foreach (var (moveButton, playerInput) in _moveHorizontal)
            {
                var dir = moveButton.ReadValue<float>();
                playerInput.MoveDirection = new Vector2Int(Mathf.RoundToInt(dir), 0);
            }

            foreach (var (moveButton, playerInput) in _moveVertical)
            {
                var dir = moveButton.ReadValue<float>();
                playerInput.MoveDirection = new Vector2Int(playerInput.MoveDirection.x, Mathf.RoundToInt(dir));
            }
        }
    }
}