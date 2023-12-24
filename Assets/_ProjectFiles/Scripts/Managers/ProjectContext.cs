using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sokoban
{
    public class ProjectContext : Singleton<ProjectContext>
    {
        [Header("References")]
        public Player Player;

        [Space]

        public GameManager GameManager;
        public PlayerInputManager PlayerInputManager;

        protected override void Awake()
        {
            base.Awake();
        }
    }
}