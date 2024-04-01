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

        [Space]
        [Header("Gizmo Properties")]
        [SerializeField] private bool _isGizmoEnabled;
        [SerializeField] private float _gizmoRadius;

        //private Cooldown _cooldownMovement;
        private Rigidbody _rigidbody;
        private Vector3 _destinationPoint;
        private Vector3 _destinationRotation;

        private Vector3 _newPosition;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            //_cooldownMovement = new Cooldown(_cellPerSecondSpeed);

            _newPosition = _rigidbody.position;
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

            _newPosition = _rigidbody.position + GetDirection3D(direction2D).normalized;

            _rigidbody.MovePosition(_newPosition);
            RotateTowards(direction2D);

            //Debug.Log($"\nDirection:    {direction2D}" +
            //          $"\nNew Position: {_newPosition}");
        }

        public void RotateTowards(Vector2 direction2D)
        {
            _rigidbody.MoveRotation(Quaternion.LookRotation(GetDirection3D(direction2D).normalized));
        }

        private Vector3 GetDirection3D(Vector2 direction2D) => new Vector3(direction2D.x, 0f, direction2D.y);
    }
}