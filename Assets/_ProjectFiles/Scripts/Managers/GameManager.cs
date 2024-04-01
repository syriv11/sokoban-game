using UnityEngine;

namespace Sokoban
{
    public class GameManager : MonoBehaviour
    {

        private UiManager _uiManager => ProjectContext.Instance.UiManager;
        private LevelLoader _levelLoader => ProjectContext.Instance.LevelLoader;

        private void Start()
        {
            
        }
    }
}