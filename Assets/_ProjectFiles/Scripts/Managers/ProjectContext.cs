using System.Collections;
using System.Collections.Generic;
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

        public GameManager GameManager;
        public PlayerInputManager PlayerInputManager;
        public SlotsController SlotsController;
        public LevelLoader LevelLoader;
        public UiManager UiManager;

        protected override void Awake()
        {
            base.Awake();
        }
    }
}