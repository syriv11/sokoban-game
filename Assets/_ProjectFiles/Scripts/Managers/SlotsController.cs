using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sokoban
{
    public class SlotsController : MonoBehaviour
    {
        //public Action AllSlotsAreFilled;

        private List<Slot> _slots = new List<Slot>();

        private LevelLoader _levelLoader => ProjectContext.Instance.LevelLoader;

        private void Start()
        {
            FindSlotsOnLevel();
        }

        private void FindSlotsOnLevel()
        {
            _slots = FindObjectsOfType<Slot>().ToList();
        }

        public void CheckAllSlots()
        {
            foreach (Slot Slot in _slots)
            {
                if (!Slot.IsFilled)
                {
                    return;
                }
            }

            Debug.Log("The level is complete");
            //AllSlotsAreFilled?.Invoke();
            _levelLoader.LoadNextLevel();
        }

        private void OnLevelLoaded()
        {
            FindSlotsOnLevel();
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
