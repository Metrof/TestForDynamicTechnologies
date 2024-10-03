using UnityEngine;
using UnityEngine.Events;

namespace TestProject
{
    public class PlayerChangePositionEvent
    {
        public readonly Vector3 NewPlayerPosition;

        public PlayerChangePositionEvent(Vector3 newPlayerPosition)
        {
            NewPlayerPosition = newPlayerPosition;
        }
    }
    public class CanvasCreatedEvent
    {
        public readonly UnityAction<float> Action;

        public CanvasCreatedEvent(UnityAction<float> action)
        {
            Action = action;
        }
    }
    public class UserFieldInputEvent
    {
        public readonly float NewDistance;

        public UserFieldInputEvent(float newDistance)
        {
            NewDistance = newDistance;
        }
    }
    public class CubeClickEvent { }
    public class StaticCubeClickEvent { }
    public class CreateUIEvent { }
}
