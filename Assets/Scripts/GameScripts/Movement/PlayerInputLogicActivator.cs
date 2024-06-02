using System;
using Domain.Constants;
using Domain.Enum;
using Systems.EventSystem;
using UnityEngine;

namespace GameScripts.Movement
{
    public class PlayerInputLogicActivator : MonoBehaviour
    {
        [SerializeField] private GameObject _wasdLogic;
        [SerializeField] private GameObject _pointAndClickLogic;
        [SerializeField] private GameObject _uiInputLogic;
        
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
                    _wasdLogic.SetActive(true);
                    _pointAndClickLogic.SetActive(false);
                    _uiInputLogic.SetActive(false);
                    break;
                case InputTypes.PointAndClick:
                    _wasdLogic.SetActive(false);
                    _pointAndClickLogic.SetActive(true);
                    _uiInputLogic.SetActive(false);
                    break;
                case InputTypes.UiInput:
                    _wasdLogic.SetActive(true);
                    _pointAndClickLogic.SetActive(false);
                    _uiInputLogic.SetActive(true);
                    break;
            }
        }
    }
}