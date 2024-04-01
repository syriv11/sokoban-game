using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sokoban
{
    [SelectionBase]
    public class Player : MonoBehaviour
    {
        public EntityMovement PlayerMovement { get; private set; }
        public CollisionChecker PlayerCollisionChecker { get; private set; }
        private PlayerInputManager _playerInputManager => ProjectContext.Instance.PlayerInputManager;

        private void Start()
        {
            PlayerMovement = GetComponent<EntityMovement>();
            PlayerCollisionChecker = GetComponent<CollisionChecker>();
        }

        private void OnMovePressed(Vector2 moveDirection2D)
        {

            if (CanMoveInDirection(moveDirection2D))
            {
                PlayerMovement.Move(moveDirection2D);
            }
        }

        private bool CanMoveInDirection(Vector2 moveDirection2D)
        {
            Collider[] colliders = PlayerCollisionChecker.CheckCollidersInDirection(moveDirection2D);

            if (colliders.Length > 0)
            {
                foreach (Collider collider in colliders)
                {
                    Debug.Log($"{gameObject.name} collided with {collider.gameObject.name}");

                    if (collider.TryGetComponent<Crate>(out Crate crate))
                    {
                        if (crate.TryGetPushed(moveDirection2D))
                        {
                            return true;
                        }
                        // TRY to move it (bool method), and if TRUE => PlayerMovement.Move()
                        PlayerMovement.RotateTowards(moveDirection2D);
                        return false;
                    }

                    else if (collider.TryGetComponent<Wall>(out Wall wall))
                    {
                        // do nothing, or do animation of trying to move and stumbling to wall
                        PlayerMovement.RotateTowards(moveDirection2D);
                        return false;
                    }

                    else
                    {

                    }
                }
            }

            return true;
        }

        private void OnEnable()
        {
            ProjectContext.Instance.PlayerInputManager.MovePressed += OnMovePressed;
        }

        private void OnDisable()
        {
            ProjectContext.Instance.PlayerInputManager.MovePressed -= OnMovePressed;
        }
    }
}