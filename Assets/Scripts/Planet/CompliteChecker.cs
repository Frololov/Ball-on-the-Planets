using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;


namespace BallOnPlanet.Planet
{
    public class CompliteChecker : MonoBehaviour
    {
        [SerializeField] private int _sceneIndex;

        private InputHandler _inputHandler;


        private void Awake()
        {
            _inputHandler = FindObjectOfType<InputHandler>();

            _inputHandler.OnEscapePressed += OnEscapePressed;
        }

        private void OnEscapePressed()
        {
            _inputHandler.OnEscapePressed -= OnEscapePressed;

            SceneManager.LoadScene(_sceneIndex, LoadSceneMode.Single);
        }
    }
}