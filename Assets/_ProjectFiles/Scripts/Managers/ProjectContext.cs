using UnityEngine;

namespace Sokoban
{
    [SelectionBase]
    public class ProjectContext : Singleton<ProjectContext>
    {
        [Header("References")]
        public Player Player;
        public PlayerCamera PlayerCamera;

        [Space]

        [Header("Managers")]
        public GameManager GameManager;
        public PlayerInputManager PlayerInputManager;
        public SlotsController SlotsController;
        public LevelLoader LevelLoader;
        public LevelProgressSaver LevelProgressSaver;
        public UiManager UiManager;
        public VibrationsHandler VibrationsHandler;

        protected override void Awake()
        {
            base.Awake();
        }
    }
}