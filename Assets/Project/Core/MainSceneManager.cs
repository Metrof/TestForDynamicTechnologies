using UnityEngine;

namespace TestProject
{
    public class MainSceneManager : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private StaticCube _secondCubePrefab;
        [SerializeField] private ParticleController _particleControllerPrefab;
        [SerializeField] private SphereSpawner _sphereSpawnerPrefab;

        [Header("Anchors")]
        [SerializeField] private Transform _secondCubePosition;
        [SerializeField] private Transform _playerStartPosition;
        [SerializeField] private Transform _environmentAnchor;
        [SerializeField] private Transform _sphereSpawnerCenterPosition;

        private Player _player;
        private StaticCube _secondCube;
        private EventBase _eventBase;
        private ParticleController _particleController;
        private SphereSpawner _sphereSpawner;
        private PlayerTeleportator _playerTeleportator;

        public void Initialization(EventBase eventBase)
        {
            _eventBase = eventBase;

            _secondCube = Instantiate(_secondCubePrefab, _environmentAnchor);
            _secondCube.transform.position = _secondCubePosition.position;
            _secondCube.Initialization(_eventBase);

            _particleController = Instantiate(_particleControllerPrefab, _environmentAnchor);
            _particleController.Initialization(_secondCube.transform.position, _eventBase);

            _player = Instantiate(_playerPrefab, _environmentAnchor);
            _player.transform.position = _playerStartPosition.position;
            _player.Initialization(_eventBase, _particleController.UpdateParticleState);

            _playerTeleportator = new PlayerTeleportator(_eventBase, _player, _secondCube.transform.position);

            _sphereSpawner = Instantiate(_sphereSpawnerPrefab, _environmentAnchor);
            _sphereSpawner.transform.position = _sphereSpawnerCenterPosition.position;
            _sphereSpawner.Initialization(_eventBase);

            _eventBase?.Invoke(new CreateUIEvent());
        }
    }
}
