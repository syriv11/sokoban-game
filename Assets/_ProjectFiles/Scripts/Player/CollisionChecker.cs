using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sokoban
{
    public class CollisionChecker : MonoBehaviour
    {
        [Header("Checker Properties")]
        [SerializeField] private Vector3 _checkerOffset;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;

        [Space]
        [Header("Gizmo Properties")]
        [SerializeField] private bool _isGizmoEnabled;
        private Vector3 _gizmoPosition;

        private int WALL_LAYER_MASK => LayerMask.GetMask("Wall");
        private int CRATE_LAYER_MASK => LayerMask.GetMask("Crate");

        public Collider[] CheckCollidersInDirection(Vector2 moveDirection2D)
        {
            Vector3 moveDirection3D = new Vector3(moveDirection2D.x, 0f, moveDirection2D.y);

            Vector3 checkerPosition = _gizmoPosition = transform.position + _checkerOffset + moveDirection3D;

            return Physics.OverlapSphere(checkerPosition, _radius, _layerMask.value);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.LogWarning($"FJKOIEJFOIJIOF !!!{gameObject.name} collided with {collision.gameObject.name}");
        }

        private void OnDrawGizmos()
        {
            if (!_isGizmoEnabled)   
                return;

            Gizmos.color = Color.red;

            if (Application.isEditor)
            {
                _gizmoPosition = transform.position + _checkerOffset;
            }

            Gizmos.DrawWireSphere(_gizmoPosition, _radius);
        }
    }
}
