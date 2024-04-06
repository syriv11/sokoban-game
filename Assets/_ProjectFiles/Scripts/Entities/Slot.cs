using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sokoban
{
    public class Slot : MonoBehaviour
    {
        public Action<bool> SlotFillChanged;

        [SerializeField] private MeshRenderer _slotRenderer;
        [SerializeField] private Material _filledMaterial;

        private bool _isFilled;
        private Material _initialMaterial;

        public bool IsFilled => _isFilled;
        private SlotsController _slotsController => ProjectContext.Instance.SlotsController;
        private VibrationsHandler VibrationsHandler => ProjectContext.Instance.VibrationsHandler;

        private void Start()
        {
            _initialMaterial = _slotRenderer.material;
        }

        private void SetFilled(bool isFilled)
        {
            _isFilled = isFilled;

            if (isFilled)
            {
                _slotRenderer.material = _filledMaterial;

                _slotsController.CheckAllSlots();

            }
            else
            {
                _slotRenderer.material = _initialMaterial;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"{gameObject.name} triggered by {other.name}");

            if (other.TryGetComponent<Crate>(out Crate crate))
            {
                SlotFillChanged?.Invoke(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Crate>(out Crate crate))
            {
                SlotFillChanged?.Invoke(false);
            }
        }

        private void OnSlotFilled(bool isFilled)
        {
            SetFilled(isFilled);

            if (isFilled)
            {
                VibrationsHandler.Vibrate();
            }
        }

        private void OnEnable()
        {
            SlotFillChanged += OnSlotFilled;
        }

        private void OnDisable()
        {
            SlotFillChanged -= OnSlotFilled;
        }
    }
}
