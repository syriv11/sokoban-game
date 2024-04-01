using System;
using UnityEngine;

namespace Sokoban
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField, InspectorName("HUD")] private GameObject Hud;
        [SerializeField] private GameObject _mainMenuUI;

        //[SerializeField] private MainMenuUI _mainMenuUI;
        private LevelLoader _levelLoader => ProjectContext.Instance.LevelLoader;

        private void Start()
        {
            SetupCurrentUi();
        }

        public void ShowMainMenu()
        {
            _mainMenuUI.SetActive(true);
            Hud.SetActive(false);
        }
        public void ShowHud()
        {
            _mainMenuUI.SetActive(false);
            Hud.SetActive(true);
        }

        private void SetupCurrentUi()
        {
            if (_levelLoader.IsMainMenu())
                ShowMainMenu();
            else
                ShowHud();
        }

        private void OnLevelLoaded()
        {
            SetupCurrentUi();
        }

        private void OnEnable()
        {
            _levelLoader.LevelLoaded += OnLevelLoaded;
        }

        private void OnDisable()
        {
            _levelLoader.LevelLoaded -= OnLevelLoaded;
        }
    }
}