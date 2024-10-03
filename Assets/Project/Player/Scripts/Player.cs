using UnityEngine;
using UnityEngine.Events;

namespace TestProject
{
    public class Player : MonoBehaviour, IPlayer
    {
        private EventBase _eventBase;
        private PlayerMovement _playerMovement;
        private MovingCube _movingCube;
        private UnityAction<Vector3> _moveAction;

        public Vector3 Pos => transform.position;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _movingCube = GetComponent<MovingCube>();
        }

        public void Initialization(EventBase eventBase, UnityAction<Vector3> OnPlayerMove)
        {
            _moveAction = OnPlayerMove;
            _eventBase = eventBase;
            _playerMovement.OnMove += _moveAction;
            _playerMovement.Enable();

            _movingCube.Initialization(_eventBase);
        }
        public void Teleport(Vector3 newPos)
        {
            transform.position = newPos;
            _moveAction?.Invoke(newPos);
        }
    }
}
