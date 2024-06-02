using Domain.Constants;
using Domain.Enum;
using Systems.EventSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameScripts.UI.Controller
{
    public class EachNavigationButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private InputDirections _inputDirection;

        public void OnPointerDown(PointerEventData eventData)
        {
            EventService.Invoke<InputDirections>(GameEvents.ON_UI_INPUT_DOWN, _inputDirection);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            EventService.Invoke<InputDirections>(GameEvents.ON_UI_INPUT_UP, _inputDirection);
        }
    }
}