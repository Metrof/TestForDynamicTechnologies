using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace TestProject
{
    public class PlayerMovement : MonoBehaviour
    {
        public UnityAction<Vector3> OnMove;

        [SerializeField] private float _movementSpeed = 1.0f;

        private Rigidbody _rb;
        Controller _controller;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _controller = new Controller();

            _controller.Gameplay.Move.performed += Move;
            _controller.Gameplay.Move.canceled += StopMove;
        }

        private void OnDisable()
        {
            _controller.Gameplay.Move.performed -= Move;
            _controller.Gameplay.Move.canceled -= StopMove;
            Disable();
        }
        public void Move(InputAction.CallbackContext context)
        {
            _rb.velocity = context.ReadValue<Vector2>() * _movementSpeed;
            StartCoroutine(MoveCoroutine());
        }
        public void StopMove(InputAction.CallbackContext context)
        {
            _rb.velocity = Vector3.zero;
        }
        public void Enable()
        {
            _controller.Enable();
        }
        public void Disable()
        {
            _controller.Disable();
        }

        private IEnumerator MoveCoroutine()
        {
            while (_rb.velocity != Vector3.zero)
            {
                OnMove?.Invoke(_rb.position);
                yield return null;
            }
        }
        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
