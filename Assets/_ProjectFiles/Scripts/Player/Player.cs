using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Sokoban
{
    [SelectionBase]
    public class Player : MonoBehaviour
    {

        public PlayerMovement PlayerMovement { get; private set; }
        private PlayerInputManager _playerInputManager => ProjectContext.Instance.PlayerInputManager;

        private void Start()
        {
            PlayerMovement = GetComponent<PlayerMovement>();
        }

        private void FixedUpdate()
        {
            if (_playerInputManager.InputWASD != Vector3.zero)
            {
                PlayerMovement.HandleMovementAsync(_playerInputManager.InputWASD);
            }
        }
    }
}