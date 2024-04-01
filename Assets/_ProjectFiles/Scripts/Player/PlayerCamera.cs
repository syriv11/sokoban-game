using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sokoban
{
    public class PlayerCamera : MonoBehaviour
    {
        private Camera _camera;

        public Camera Camera => _camera ??= GetComponent<Camera>();
    }
}
