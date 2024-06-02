using System;
using Domain.Constants;
using Domain.Enum;
using Systems.EventSystem;
using UnityEngine;

namespace GameScripts.UI.Controller
{
    public class UiInputActivator : MonoBehaviour
    {
        [SerializeField] private GameObject _uiInputObject;

        private void OnEnable()
        {
            EventService.Subscribe<InputTypes>(GameEvents.ON_PLAYER_INPUT_CHANGE, OnPlayerInputChange);
        }

        private void OnDisable()
        {
            EventService.Unsubscribe<InputTypes>(GameEvents.ON_PLAYER_INPUT_CHANGE, OnPlayerInputChange);
        }

        private void OnPlayerInputChange(InputTypes inputType)
        {
            switch (inputType)
            {
                case InputTypes.Wasd:
                case InputTypes.PointAndClick:
                    _uiInputObject.SetActive(false);
                    break;
                case InputTypes.UiInput:
                    _uiInputObject.SetActive(true);
                    break;
            }
        }
    }
}