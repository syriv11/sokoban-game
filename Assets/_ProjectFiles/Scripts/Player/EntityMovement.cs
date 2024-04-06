using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Sokoban
{
    public class EntityMovement : MonoBehaviour
    {
        [Header("Properties")]
        //[SerializeField] private float _cellPerSecondSpeed;
        [SerializeField] private bool _rotateTowardsMovementDirection;

        [Space]
        [Header("Gizmo Properties")]
        [SerializeField] private bool _isGizmoEnabled;
        [SerializeField] private float _gizmoRadius;

        //private Cooldown _cooldownMovement;
        private Rigidbody _rigidbody;
        private Vector3 _destinationPoint;
        private Vector3 _destinationRotation;

        private Vector3 _newPosition;
        private Quaternion _newRotation;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            //_cooldownMovement = new Cooldown(_cellPerSecondSpeed);

            _newPosition = _rigidbody.position;
            _newRotation = transform.rotation;
        }

        private void Update()
        {
            _rigidbody.MovePosition(Vector3.Lerp(_newPosition, _rigidbody.position, 0.5f));

            if (_rotateTowardsMovementDirection)
                _rigidbody.MoveRotation(Quaternion.Lerp(_newRotation, _rigidbody.rotation, 0.5f));
        }

        public void Move(Vector2 direction2D)
        {
            //if (isPressedFirstTime)
            //    _cooldownMovement.Cancel();

            //if (_cooldownMovement.IsEnabled)
            //    return;

            //_cooldownMovement.StartAsync();

            //if (!isPressedFirstTime)
            //    return;

            _newPosition = _newPosition + GetDirection3D(direction2D).normalized;

            if (_rotateTowardsMovementDirection)
            {
                RotateTowards(direction2D);
            }


            //Debug.Log($"\nDirection:    {direction2D}" +
            //          $"\nNew Position: {_newPosition}");
        }

        public void RotateTowards(Vector2 direction2D)
        {
            _newRotation = Quaternion.LookRotation(GetDirection3D(direction2D).normalized);
        }

        private Vector3 GetDirection3D(Vector2 direction2D) => new Vector3(direction2D.x, 0f, direction2D.y);
    }
}