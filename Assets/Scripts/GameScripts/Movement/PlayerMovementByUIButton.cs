using Domain.Constants;
using Domain.Enum;
using GameScripts.Movement.Abstract;
using Systems.EventSystem;
using UnityEngine;

namespace GameScripts.Movement
{
    public class PlayerMovementByUIButton : PlayerMovement
    {
        [SerializeField] private Transform _rootTransform;

        private Quaternion _inputRotation = Quaternion.identity;
        int _movement = 0;

        private void OnEnable()
        {
            EventService.Subscribe<InputDirections>(GameEvents.ON_UI_INPUT_DOWN, OnUiInputDown);
            EventService.Subscribe<InputDirections>(GameEvents.ON_UI_INPUT_UP, OnUiInputUp);

            Movement = CurrenMovement = Vector3.zero;
            _rigidbody.velocity = CurrenMovement;
        }

        private void OnDisable()
        {
            EventService.Unsubscribe<InputDirections>(GameEvents.ON_UI_INPUT_DOWN, OnUiInputDown);
            EventService.Unsubscribe<InputDirections>(GameEvents.ON_UI_INPUT_UP, OnUiInputUp);
        }

        private void FixedUpdate()
        {
            Movement = (_rootTransform.forward * _movement).normalized;
            CurrenMovement = Vector3.Lerp(CurrenMovement, Movement, _easeSpeed * Time.deltaTime);
            _rigidbody.velocity = CurrenMovement * _movementSpeed;

            _rigidbody.MoveRotation(_rigidbody.rotation * _inputRotation);
        }

        private void OnUiInputDown(InputDirections inputDirection)
        {
            switch (inputDirection)
            {
                case InputDirections.Forward:
                    _movement = 1;
                    break;
                case InputDirections.Backward:
                    _movement = -1;
                    break;
                case InputDirections.RotateLeft:
                    _inputRotation = Quaternion.Euler(0, -1, 0);
                    break;
                case InputDirections.RotateRight:
                    _inputRotation = Quaternion.Euler(0, 1, 0);
                    break;
            }
        }

        private void OnUiInputUp(InputDirections inputDirection)
        {
            switch (inputDirection)
            {
                case InputDirections.Forward:
                case InputDirections.Backward:
                    _movement = 0;
                    break;
                case InputDirections.RotateLeft:
                case InputDirections.RotateRight:
                    _inputRotation = Quaternion.identity;
                    break;
            }
        }

        public override void OnMovementChanged(Vector3 movement)
        {
        }
    }
}