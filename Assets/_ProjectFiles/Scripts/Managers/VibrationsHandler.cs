using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CandyCoded.HapticFeedback;

namespace Sokoban
{
    public class VibrationsHandler : MonoBehaviour
    {
        [SerializeField] private bool _isVibroEnabled;

        public bool IsVibroEnabled { get { return _isVibroEnabled; } }

        public void Vibrate()
        {
            if (IsVibroEnabled)
            {
                Debug.Log("BRRRRRRR *vibro*");

                //Handheld.Vibrate();
                //HapticFeedback.LightFeedback();
                HapticFeedback.MediumFeedback();

                //HapticFeedback.HeavyFeedback();
            }
        }

        public void SetVibration(bool isEnabled)
        {
            _isVibroEnabled = isEnabled;
        }
    }
}
