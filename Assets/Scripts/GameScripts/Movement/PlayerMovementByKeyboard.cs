using Domain.Constants;
using GameScripts.Movement.Abstract;
using Systems.EventSystem;
using UnityEngine;

namespace GameScripts.Movement
{
    public class PlayerMovementByKeyboard : PlayerMovement
    {
        private void OnEnable()
        {
            EventService.Subscribe<Vector3>(GameEvents.ON_MOVEMENT_CHANGE, OnMovementChanged);
            Movement = CurrenMovement = Vector3.zero;
            _rigidbody.velocity = CurrenMovement;
        }

        private void OnDisable()
        {
            EventService.Subscribe<Vector3>(GameEvents.ON_MOVEMENT_CHANGE, OnMovementChanged);
        }

        private void FixedUpdate()
        {
            CurrenMovement = Vector3.Lerp(CurrenMovement, Movement, _easeSpeed * Time.deltaTime);
            _rigidbody.velocity = CurrenMovement * _movementSpeed;
        }

        public override void OnMovementChanged(Vector3 movement)
        {
            Movement = new Vector3(movement.x, 0, movement.y);
        }
    }
}