using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class SphereSpawner : MonoBehaviour
    {
        [SerializeField] private List<Material> _materials;
        [SerializeField] private CustomSphere _spherePrefab;
        [SerializeField] private float _createRadius = 5;

        private Pool<CustomSphere> _spherePool;
        private List<CustomSphere> _activeSpheres;

        private EventBase _eventBase;
        private bool _isSphereCreated = false;

        private void Start()
        {
            _activeSpheres = new List<CustomSphere>();
            var list = new List<CustomSphere>();
            for (int i = 0; i < _materials.Count; i++)
            {
                var sphere = Instantiate(_spherePrefab, transform);
                sphere.gameObject.SetActive(false);
                list.Add(sphere);
            }
            _spherePool = new Pool<CustomSphere>(list);
        }
        public void Initialization(EventBase eventBase)
        {
            _eventBase = eventBase;
            _eventBase?.Subscribe<StaticCubeClickEvent>(CheckSphereStatus);
        }
        private void CheckSphereStatus(StaticCubeClickEvent clickEvent)
        {
            if (_isSphereCreated)
            {
                DeleteSphere();
            }
            else
            {
                CreateSphere();
            }
        }
        private void CreateSphere()
        {
            for (int i = 0; i < _materials.Count; i++)
            {
                if (_spherePool.TryInstantiate(out CustomSphere sphere, Random.insideUnitSphere * _createRadius, Quaternion.identity))
                {
                    sphere.ChangeMaterial(_materials[i]);
                    _activeSpheres.Add(sphere);
                }
            }
            _isSphereCreated = true;
        }
        private void DeleteSphere()
        {
            foreach (var sphere in _activeSpheres)
            {
                sphere.SphereOff();
            }
            _activeSpheres.Clear();
            _isSphereCreated = false;
        }
    }
}
