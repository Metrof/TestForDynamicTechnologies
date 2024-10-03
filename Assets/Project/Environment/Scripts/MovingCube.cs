using UnityEngine;
using UnityEngine.EventSystems;

namespace TestProject
{
    public class MovingCube : MonoBehaviour, IPointerClickHandler
    {
        private EventBase _eventBase;

        public void Initialization(EventBase eventBase)
        {
            _eventBase = eventBase;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            _eventBase?.Invoke(new CubeClickEvent());
        }
    }
}
