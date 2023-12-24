using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Sokoban
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private float _cellPerSecondSpeed;

        [Space]
        [Header("Gizmo Properties")]
        [SerializeField] private bool _isGizmoEnabled;
        [SerializeField] private float _gizmoRadius;

        private Cooldown _cooldownMovement;
        private Rigidbody _rigidbody;
        private Vector3 _destinationPoint;
        private Vector3 _destinationRotation;

        private Vector3 _newPosition;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _cooldownMovement = new Cooldown(_cellPerSecondSpeed);

            _newPosition = _rigidbody.position;
        }

        public void HandleMovementAsync(Vector3 input)
        {
            if (_cooldownMovement.IsEnabled)
                return;

            _cooldownMovement.StartAsync();

            _newPosition = _rigidbody.position + input;

            _rigidbody.MovePosition(_newPosition);
            _rigidbody.MoveRotation(Quaternion.LookRotation(input));
        }

        private void OnDrawGizmos()
        {
            if (!_isGizmoEnabled)
                return;

            Gizmos.color = Color.red;

            Gizmos.DrawWireSphere(_newPosition, _gizmoRadius);
        }
    }
}