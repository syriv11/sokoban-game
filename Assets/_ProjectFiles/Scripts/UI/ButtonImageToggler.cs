using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sokoban
{
    public class ButtonImageToggler : MonoBehaviour
    {
        [SerializeField] private GameObject _iconOn;
        [SerializeField] private GameObject _iconOff;

        public bool IsOn { get; private set; }

        public void Toggle()
        {
            SetEnabled(!IsOn);
        }

        public void SetEnabled(bool isEnabled)
        {
            IsOn = isEnabled;

            UpdateIcon();
        }

        private void UpdateIcon()
        {
            _iconOn.SetActive(IsOn);
            _iconOff.SetActive(!IsOn);
        }
    }
}
