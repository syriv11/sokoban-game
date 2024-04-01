using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sokoban
{
    public class LevelLoader : MonoBehaviour
    {
        public Action LevelLoaded;

        [SerializeField] private string _mainMenuSceneName;
        [SerializeField] private List<string> _levelsNames = new List<string>();

        [SerializeField] private Animator _transition;

        [SerializeField] private float _transitionTime = 1f;

        private const string TRANSITION_SPEED_MULTIPLIER = "SpeedMultiplier";

        private void Start()
        {
            _transition.SetFloat(TRANSITION_SPEED_MULTIPLIER, 1 / _transitionTime);
        }

        public void LoadNextLevel()
        {
            int currentSceneIndex = _levelsNames.FindIndex(x => x == GetCurrentSceneName());

            if (currentSceneIndex == -1)
            {
                return;
            }

            if (currentSceneIndex == _levelsNames.Count - 1)
                BackToMenu();
            else
                LoadLevel(currentSceneIndex + 1);
                //LoadLevelByName(GetCurrentSceneIndex() + 1);
        }

        public void BackToMenu()
        {
            LoadLevelByName(_mainMenuSceneName);
        }

        public void RestartCurrentLevel()
        {
            LoadLevelByName(GetCurrentSceneName());
        }

        public void LoadLevel(int levelIndex)
        {
            //LoadLevelByName(SceneManager.GetSceneByName(_levels[levelIndex]).buildIndex);
            LoadLevelByName(_levelsNames[levelIndex]);
        }   

        public void LoadLevelByName(string levelName)
        {
            StartCoroutine(LoadLevelCoroutine(levelName));
        }

        IEnumerator LoadLevelCoroutine(string levelName)
        {
            _transition.SetTrigger("Start");

            yield return new WaitForSeconds(_transitionTime);

            SceneManager.LoadScene(levelName);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            LevelLoaded?.Invoke();  
        }

        public bool IsMainMenu() => SceneManager.GetActiveScene().name == _mainMenuSceneName;

        //private static int GetCurrentSceneIndex() => SceneManager.GetActiveScene().buildIndex;
        private static string GetCurrentSceneName() => SceneManager.GetActiveScene().name;

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}