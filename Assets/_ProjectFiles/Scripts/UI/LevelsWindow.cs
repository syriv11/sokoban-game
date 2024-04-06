using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sokoban
{
    public class LevelsWindow : MonoBehaviour
    {
        [SerializeField] private List<LevelButton> _levelButtons;

        private LevelProgressSaver _levelProgressSaver => ProjectContext.Instance.LevelProgressSaver;
        private LevelLoader _levelLoader => ProjectContext.Instance.LevelLoader;

        private void OnEnable()
        {
            RefreshAllLevelButtons();
        }

        private void RefreshAllLevelButtons()
        {
            List<string> levelNames = _levelLoader.GetAllLevelNames();

            foreach (LevelButton levelButton in _levelButtons)
            {
                bool isLevelUnlocked;

                if (levelButton.LevelIndex >= levelNames.Count)
                    isLevelUnlocked = false;
                else
                    isLevelUnlocked = _levelProgressSaver.IsLevelUnlocked(levelNames?[levelButton.LevelIndex]);

                levelButton.SetLevelLockedView(isLevelUnlocked);
            }
        }
    }
}
