using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.Rendering;
using UnityEngine;

namespace Sokoban
{
    public class PlayerInputManager : MonoBehaviour
    {
        public Action<Vector2> MovePressed;

        private Vector2 _moveDirection = Vector2.zero;
        private Vector2 _lastMoveDirection;

        private bool _isKeyPressedFirstTime = false;

        public Vector2 MoveDirection => _moveDirection;
        public SwipeController SwipeController { get; private set; }

        private void Start()
        {
            SwipeController = GetComponent<SwipeController>();
            SwipeController.SwipePerformed += OnSwipePerformed;
        }

        private void OnSwipePerformed(SwipeDirection swipeDirection)
        {
            //Debug.Log($"SwipeDirection: {swipeDirection}");

            switch (swipeDirection)
            {
                case SwipeDirection.None:
                    return;

                case SwipeDirection.Up:
                    _moveDirection = new Vector2(0f, 1f);
                    break;
                case SwipeDirection.Down:
                    _moveDirection = new Vector2(0f, -1f);
                    break;
                case SwipeDirection.Left:
                    _moveDirection = new Vector2(-1f, 0f);
                    break;
                case SwipeDirection.Right:
                    _moveDirection = new Vector2(1f, 0f);
                    break;
            }

            MovePressed?.Invoke(MoveDirection);
        }

        private void Update()
        {
            SwipeController.HandleSwipes();
            //GetPlayerkeyboardInput();
        }

        //private void GetPlayerkeyboardInput()
        //{
        //    // Movement

        //    _lastMoveDirection = _moveDirection;

        //    _moveDirection = new Vector2
        //    (
        //        Input.GetAxisRaw("Horizontal"), 
        //        Input.GetAxisRaw("Vertical")
        //    );

        //    if ((_lastMoveDirection != _moveDirection))
        //    {
        //        _isKeyPressedFirstTime = true;
        //    }
        //    else
        //    {
        //        _isKeyPressedFirstTime = false;
        //    }

        //    if (_moveDirection != Vector2.zero)
        //    {
        //        MovePressed?.Invoke(MoveDirection, _isKeyPressedFirstTime);
        //    }
        //}
    }
}