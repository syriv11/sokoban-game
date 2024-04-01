using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sokoban
{
    public class Crate : MonoBehaviour
    {
        public EntityMovement CrateMovement { get; private set; }
        public CollisionChecker CrateCollisionChecker { get; private set; }
        //private PlayerInputManager _playerInputManager => ProjectContext.Instance.PlayerInputManager;

        private void Start()
        {
            CrateMovement = GetComponent<EntityMovement>();
            CrateCollisionChecker = GetComponent<CollisionChecker>();
        }

        private void OnMovePressed(Vector2 moveDirection2D)
        {

            if (CanMoveInDirection(moveDirection2D))
            {
                CrateMovement.Move(moveDirection2D);
            }
        }

        public bool TryGetPushed(Vector2 moveDirection2D)
        {
            if (CanMoveInDirection(moveDirection2D))
            {
                CrateMovement.Move(moveDirection2D);
                return true;
            }

            return false;
        }

        private bool CanMoveInDirection(Vector2 moveDirection2D)
        {
            Collider[] colliders = CrateCollisionChecker.CheckCollidersInDirection(moveDirection2D);

            if (colliders.Length > 0)
            {
                foreach (Collider collider in colliders)
                {
                    Debug.Log($"{gameObject.name} collided with {collider.gameObject.name}");

                    if (collider.TryGetComponent<Crate>(out Crate crate))
                    {
                        // TRY to move it (bool method), and if TRUE => PlayerMovement.Move()
                        return false;
                    }

                    else if (collider.TryGetComponent<Wall>(out Wall wall))
                    {
                        // do nothing, or do animation of trying to move and stumbling to wall
                        //CrateMovement.RotateTowards(moveDirection2D);
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
