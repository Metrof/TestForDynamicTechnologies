using UnityEngine;

namespace TestProject
{
    public class CustomSphere : PooledItem
    {
        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        public void ChangeMaterial(Material material)
        {
            _renderer.material = material;
        }
        public void SphereOff()
        {
            ReturnToPool();
        }
    }
}
