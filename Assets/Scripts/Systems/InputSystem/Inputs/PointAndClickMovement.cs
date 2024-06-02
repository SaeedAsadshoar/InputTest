using Domain.Constants;
using Systems.EventSystem;
using UnityEngine;

namespace Systems.InputSystem.Inputs
{
    public class PointAndClickMovement : MonoBehaviour
    {
        [SerializeField] private Camera _gameCamera;
        [SerializeField] private LayerMask _groundLayer;

        private Vector3 _targetPoint;

        private GameObject _lastPoint;
        private Transform _lastPointTransform;

        private void OnDisable()
        {
            if (_lastPoint != null)
            {
                Destroy(_lastPoint.gameObject);
            }
        }

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                var ray = _gameCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity, _groundLayer))
                {
                    _targetPoint = hit.point;
                    _targetPoint.y = 0;

                    if (_lastPoint == null)
                    {
                        _lastPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        _lastPointTransform = _lastPoint.transform;
                    }

                    _lastPointTransform.position = _targetPoint;
                    EventService.Invoke<Vector3>(GameEvents.ON_TARGET_POINT_CHANGED, _targetPoint);
                }
            }
        }
    }
}