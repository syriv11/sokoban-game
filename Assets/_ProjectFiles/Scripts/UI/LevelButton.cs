using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sokoban
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private int _levelIndex;
        [SerializeField] private GameObject _lockedView;

        private Button _button;
        private LevelLoader _levelLoader => ProjectContext.Instance.LevelLoader;

        public bool IsUnlocked { get; private set; }
        public int LevelIndex => _levelIndex;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void SetLevelLockedView(bool isUnlocked)
        {
            IsUnlocked = isUnlocked;
            _lockedView.SetActive(!isUnlocked);
        }

        private void OnButtonClick()
        {
            if (IsUnlocked)
                _levelLoader.LoadLevel(_levelIndex);
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }
    }
}
