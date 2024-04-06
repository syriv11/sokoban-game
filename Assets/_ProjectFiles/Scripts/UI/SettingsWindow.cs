using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sokoban
{
    public class SettingsWindow : MonoBehaviour
    {
        [SerializeField] private Button _vibrationButton;
        
        private ButtonImageToggler _vibrationButtonImageToggler;

        private VibrationsHandler _vibrationHandler => ProjectContext.Instance.VibrationsHandler;

        private void Start()
        {
            _vibrationButtonImageToggler = _vibrationButton.GetComponent<ButtonImageToggler>();

            _vibrationButtonImageToggler.SetEnabled(_vibrationHandler.IsVibroEnabled);
        }

        private void OnVibrationButtonClick()
        {
            _vibrationHandler.SetVibration(!_vibrationHandler.IsVibroEnabled);
            _vibrationButtonImageToggler.Toggle();
        }

        private void OnEnable()
        {
            Debug.Log("_vibrationButton.onClick.AddListener(OnVibrationButtonClick);");
            _vibrationButton.onClick.AddListener(OnVibrationButtonClick);
        }

        private void OnDisable()
        {
            _vibrationButton.onClick.RemoveListener(OnVibrationButtonClick);
        }
    }
}
