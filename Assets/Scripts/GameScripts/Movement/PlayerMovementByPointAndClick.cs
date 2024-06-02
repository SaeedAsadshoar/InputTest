using Domain.Constants;
using GameScripts.Movement.Abstract;
using Systems.EventSystem;
using UnityEngine;

namespace GameScripts.Movement
{
    public class PlayerMovementByPointAndClick : PlayerMovement
    {
        [SerializeField] private Transform _rootTransform;

        private Vector3 _target;
        private Transform _transform;

        private void OnEnable()
        {
            _transform = transform;
            EventService.Subscribe<Vector3>(GameEvents.ON_TARGET_POINT_CHANGED, OnMovementChanged);
            Movement = CurrenMovement = Vector3.zero;
            _rigidbody.velocity = CurrenMovement;
            _target = _transform.position;
        }

        private void OnDisable()
        {
            EventService.Subscribe<Vector3>(GameEvents.ON_TARGET_POINT_CHANGED, OnMovementChanged);
        }

        private void FixedUpdate()
        {
            Movement = _target - _transform.position;
            Movement.y = 0;
            CurrenMovement = Vector3.Lerp(CurrenMovement, Movement, _easeSpeed * Time.deltaTime);
            _rigidbody.velocity = CurrenMovement * _movementSpeed;
        }

        public override void OnMovementChanged(Vector3 target)
        {
            _target = target;
            _target.y = 0;

            target.y = _rootTransform.position.y;
            _rootTransform.LookAt(target);
        }
    }
}