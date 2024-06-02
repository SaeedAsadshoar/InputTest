using Domain.Constants;
using Domain.Enum;
using Systems.EventSystem;
using UnityEngine;

namespace GameScripts
{
    public class PlayerInputChanger : MonoBehaviour
    {
        [SerializeField] private GameObject _wasdLogic;
        [SerializeField] private GameObject _pointAndClickLogic;

        private void OnEnable()
        {
            Invoke(nameof(StartGame), 1);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _wasdLogic.SetActive(true);
                _pointAndClickLogic.SetActive(false);

                EventService.Invoke<InputTypes>(GameEvents.ON_PLAYER_INPUT_CHANGE, InputTypes.Wasd);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _wasdLogic.SetActive(false);
                _pointAndClickLogic.SetActive(true);

                EventService.Invoke<InputTypes>(GameEvents.ON_PLAYER_INPUT_CHANGE, InputTypes.PointAndClick);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _wasdLogic.SetActive(false);
                _pointAndClickLogic.SetActive(false);

                EventService.Invoke<InputTypes>(GameEvents.ON_PLAYER_INPUT_CHANGE, InputTypes.UiInput);
            }
        }
        
        private void StartGame()
        {
            _wasdLogic.SetActive(true);
            _pointAndClickLogic.SetActive(false);
            
            EventService.Invoke<InputTypes>(GameEvents.ON_PLAYER_INPUT_CHANGE, InputTypes.Wasd);
        }
    }
}