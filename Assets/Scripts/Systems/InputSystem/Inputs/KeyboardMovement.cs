using Domain.Constants;
using Systems.EventSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.InputSystem.Inputs
{
    public class KeyboardMovement : MonoBehaviour
    {
        private CostumeInput _costumeInput = null;
        private Vector2 _moveVector = Vector2.zero;

        private void Awake()
        {
            _costumeInput = new CostumeInput();
        }

        private void OnEnable()
        {
            _costumeInput.Enable();
            _costumeInput.Player.Movement.performed += MovementOnPerformed;
            _costumeInput.Player.Movement.canceled += MovementOnCanceled;
        }

        private void OnDisable()
        {
            _costumeInput.Disable();
            _costumeInput.Player.Movement.performed -= MovementOnPerformed;
            _costumeInput.Player.Movement.canceled -= MovementOnCanceled;
        }

        private void MovementOnPerformed(InputAction.CallbackContext value)
        {
            _moveVector = value.ReadValue<Vector2>();
            EventService.Invoke<Vector3>(GameEvents.ON_MOVEMENT_CHANGE, _moveVector);
        }

        private void MovementOnCanceled(InputAction.CallbackContext value)
        {
            _moveVector = Vector2.zero;
            EventService.Invoke<Vector3>(GameEvents.ON_MOVEMENT_CHANGE, _moveVector);
        }
    }
}