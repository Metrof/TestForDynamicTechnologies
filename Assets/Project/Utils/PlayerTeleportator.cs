using UnityEngine;

namespace TestProject
{
    public class PlayerTeleportator 
    {
        private EventBase _eventBase;
        private IPlayer _player;
        private Vector3 _staticCubePos;

        public PlayerTeleportator(EventBase eventBase, IPlayer player, Vector3 staticCubePos)
        {
            _eventBase = eventBase;
            _player = player;
            _staticCubePos = staticCubePos;

            _eventBase?.Subscribe<UserFieldInputEvent>(ChangePlayerPos);
        }
        private void ChangePlayerPos(UserFieldInputEvent inputEvent)
        {
            var direction = _player.Pos - _staticCubePos;
            var normalizeDir = direction.normalized;
            _player.Teleport(_staticCubePos + normalizeDir * inputEvent.NewDistance);
        }
    }
}
