using System;
using UnityEngine;

namespace Sokoban
{
    public enum SwipeDirection
    {
        None, Up, Down, Left, Right
    }

    public class SwipeController : MonoBehaviour
    {
        public Action<SwipeDirection> SwipePerformed;

        [SerializeField] private bool _isContinuedSwipe;
        [SerializeField] private float _swipeDragThreshold = 200f;

        private bool _waitForSwipe;
        private Vector2 _touchPositionFirst;
        private Vector2 _touchPositionLast;

        private Vector2 _touchMoveDelta;
        private SwipeDirection _swipeDirection;

        public SwipeDirection SwipeDirection => _swipeDirection;

        private float sizeMultiplier;

        public void HandleSwipes()
        {
            if (Input.touches.Length == 1)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    _waitForSwipe = true;
                    _touchPositionFirst = touch.position;
                }

                if (touch.phase == TouchPhase.Moved)
                {

                }

                if (touch.phase == TouchPhase.Ended)
                {
                    _touchPositionLast = touch.position;
                    _touchMoveDelta = _touchPositionLast - _touchPositionFirst;

                    // Make sure it was a legit swipe, not a tap
                    if (_touchMoveDelta.magnitude < _swipeDragThreshold)
                    {
                        _swipeDirection = SwipeDirection.None;
                        return;
                    }

                    _touchMoveDelta.Normalize();

                    if (_touchMoveDelta.y > 0 && _touchMoveDelta.x > -0.5f && _touchMoveDelta.x < 0.5f)
                    {
                        // Swipe up
                        _swipeDirection = SwipeDirection.Up;
                    }
                    else if (_touchMoveDelta.y < 0 && _touchMoveDelta.x > -0.5f && _touchMoveDelta.x < 0.5f)
                    {
                        // Swipe down
                        _swipeDirection = SwipeDirection.Down;
                    }
                    else if (_touchMoveDelta.x < 0 && _touchMoveDelta.y > -0.5f && _touchMoveDelta.y < 0.5f)
                    {
                        // Swipe left
                        _swipeDirection = SwipeDirection.Left;
                    }
                    else if (_touchMoveDelta.x > 0 && _touchMoveDelta.y > -0.5f && _touchMoveDelta.y < 0.5f)
                    {
                        // Swipe right
                        _swipeDirection = SwipeDirection.Right;
                    }
                }

                SwipePerformed.Invoke(_swipeDirection);
            }
            else
            {
                _swipeDirection = SwipeDirection.None;
            }
        }

        //private void OnGUI()
        //{
        //    Debug.Log($"{ProjectContext.Instance.PlayerCamera.Camera.pixelRect}");

        //    //Vector2 labelSize = new Vector2(0.1, 0.1);
        //    sizeMultiplier = GUI.HorizontalSlider(new Rect(new Vector2(10, 10), new Vector2(100, 20)),
        //                                          sizeMultiplier, 0f, 10f);

        //    GUI.Label(new Rect(new Vector2(10, 10) * sizeMultiplier, new Vector2(100, 20) * sizeMultiplier), "Hello world!");
        //}
    }
}