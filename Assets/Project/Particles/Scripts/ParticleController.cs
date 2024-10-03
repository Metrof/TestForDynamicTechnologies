using UnityEngine;
using UnityEngine.Events;

namespace TestProject
{
    public class ParticleController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _firstParticleSystem;
        [SerializeField] private ParticleSystem _secondParticleSystem;
        [SerializeField] private float _minActivateDistance = 2;
        [SerializeField] private float _particleSpeed = 2;
        [SerializeField] private float _distanceFromCenter = 0.3f;

        private EventBase _eventBase;
        private Vector3 _staticCubePosition;
        private bool _active = false;
        private UnityAction<float> OnDistantionChange;
        private void Awake()
        {
            DisableParticles();
        }
        private void SubscribeEvent(CanvasCreatedEvent canvasCreated)
        {
            OnDistantionChange += canvasCreated.Action;
        }
        public void Initialization(Vector3 staticCubePosition, EventBase eventBase)
        {
            _eventBase = eventBase;
            _eventBase?.Subscribe<CanvasCreatedEvent>(SubscribeEvent);

            _staticCubePosition = staticCubePosition;
        }
        public void EnableParticles()
        {
            _firstParticleSystem.gameObject.SetActive(true);
            _secondParticleSystem.gameObject.SetActive(true);
            _firstParticleSystem.Play();
            _secondParticleSystem.Play();
            _active = true;
        }
        public void DisableParticles()
        {
            _firstParticleSystem.Pause();
            _secondParticleSystem.Pause();
            _firstParticleSystem.gameObject.SetActive(false);
            _secondParticleSystem.gameObject.SetActive(false);
            _active = false;
        }

        public void UpdateParticleState(Vector3 newPlayerPos)
        {
            var directionFromCubeToPlayer = newPlayerPos - _staticCubePosition;
            float distanceBetweenPlayerAndCube = directionFromCubeToPlayer.magnitude;
            var normalized = directionFromCubeToPlayer.normalized;

            var firstForse = _firstParticleSystem.forceOverLifetime;
            firstForse.x = -normalized.x * _particleSpeed;
            firstForse.y = -normalized.y * _particleSpeed;
            var secondForse = _secondParticleSystem.forceOverLifetime;
            secondForse.x = normalized.x * _particleSpeed;
            secondForse.y = normalized.y * _particleSpeed;

            transform.position = normalized * (distanceBetweenPlayerAndCube/2) + _staticCubePosition;
            _firstParticleSystem.transform.position = transform.position + normalized * _distanceFromCenter;
            _secondParticleSystem.transform.position = transform.position - normalized * _distanceFromCenter;

            if (distanceBetweenPlayerAndCube > _minActivateDistance)
            {
                if (_active)
                {
                    DisableParticles();
                }
            }
            else
            {
                if (!_active)
                {
                    EnableParticles();
                }
            }

            OnDistantionChange?.Invoke(distanceBetweenPlayerAndCube);
        }
    }
}
