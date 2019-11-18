using System.Collections;
using System.Collections.Generic;

using UnityEngine;


namespace BallOnPlanet
{
    public class InputHandler : MonoBehaviour
    {
        #region Private
        private Camera _camera;
        private Camera Camera
        {
            get
            {
                if (_camera == null || !_camera.gameObject.activeInHierarchy)
                    _camera = Camera.main;

                return _camera;
            }
        }
        #endregion

        #region Public
        public delegate void EscapePressedAction();
        public event EscapePressedAction OnEscapePressed;
        #endregion


        public bool GetTouch(out Vector2 result)
        {
            result = Vector2.zero;

#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IPHONE)
            if (Input.touchCount == 0)
                return false;

            result = Camera.ScreenToWorldPoint(Input.GetTouch(0).position);
#else
            if (!Input.GetMouseButton(0))
                return false;

            result = Camera.ScreenToWorldPoint(Input.mousePosition);
#endif

            return true;
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                OnEscapePressed?.Invoke();
        }
    }
}