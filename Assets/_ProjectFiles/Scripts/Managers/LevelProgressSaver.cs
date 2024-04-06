using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sokoban
{
    public class LevelProgressSaver : MonoBehaviour
    {
        //private LevelLoader _levelLoader => ProjectContext.Instance.LevelLoader;

        //private void Start()
        //{
        //    RefreshLevelProgress();
        //}

        //public void RefreshLevelProgress()
        //{
        //    foreach (string levelName in _levelLoader.GetAllLevelNames())
        //    {

        //    }
        //}

        public void UnlockLevel(string levelName)
        {
            if (!PlayerPrefs.HasKey(levelName))
                PlayerPrefs.SetInt(levelName, 1);
        }

        public bool IsLevelUnlocked(string levelName)
        {
            return PlayerPrefs.HasKey(levelName);
        }
    }
}
