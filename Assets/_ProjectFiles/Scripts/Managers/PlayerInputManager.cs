using System;
using UnityEngine;

namespace Sokoban
{
    //public enum MoveDirection
    //{
    //    Up, Down, Left, Right
    //}

    public class PlayerInputManager : MonoBehaviour
    {
        public Action<Vector3> MovePressed;
        [HideInInspector] public Vector3 InputWASD;

        private Vector3 _moveDirection;
        public Vector3 MoveDirection => _moveDirection;

        private void Update()
        {
            GetPlayerInput();
        }

        private void GetPlayerInput()
        {
            // Movement
            InputWASD = new Vector3(
                Input.GetAxis("Horizontal"),
                0f,
                Input.GetAxis("Vertical")
            );

            //Vector3 moveDirection = new Vector3
            //    (
            //        Input.GetKey(KeyCode.W)
            //    );

            

            if (Input.GetKey(KeyCode.W))
            {
                _moveDirection.x = 1f;
            }

            if (Input.GetKey(KeyCode.S))
            {
                _moveDirection.x = -1f;
            }

            MovePressed.Invoke(MoveDirection);
        }
    }
}