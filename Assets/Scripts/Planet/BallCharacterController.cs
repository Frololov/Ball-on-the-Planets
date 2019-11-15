using System.Collections;
using System.Collections.Generic;

using UnityEngine;


namespace BallOnPlanet.Planet
{
    public class BallCharacterController : MonoBehaviour
    {
        #region Editor
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _force;
        #endregion

        #region Private
        private InputHandler _inputHandler;

        private Vector2 _touchPosition;
        private bool _isTouchGetted;

        private Vector2 _forceDirection;
        #endregion


        private void Awake()
        {
            _inputHandler = FindObjectOfType<InputHandler>();

            if (_inputHandler == null)
            {
                enabled = false;
                throw new System.NullReferenceException($"Scene must contain {nameof(InputHandler)}");
            }
        }

        private void Update()
        {
            _isTouchGetted = _inputHandler.GetTouch(out _touchPosition);
        }

        private void FixedUpdate()
        {
            if (!_isTouchGetted)
                return;

            _forceDirection = _touchPosition - (Vector2)transform.position;

            _rigidbody2D.AddForce(_forceDirection.normalized * _force);
        }
    }
}