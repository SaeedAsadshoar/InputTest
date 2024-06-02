using UnityEngine;

namespace GameScripts.Movement.Abstract
{
    public abstract class PlayerMovement : MonoBehaviour
    {
        [SerializeField] protected Rigidbody _rigidbody;
        [SerializeField] protected float _movementSpeed = 1;
        [SerializeField] protected float _easeSpeed = 1;
        
        protected Vector3 Movement;
        protected Vector3 CurrenMovement;
        
        private void Awake()
        {
            _rigidbody.GetComponent<Rigidbody>();
        }
        
        public abstract void OnMovementChanged(Vector3 movement);
    }
}