using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using BallOnPlanet.Data;


namespace BallOnPlanet.MainMenu
{
    public class PlanetLevelLoader : MonoBehaviour
    {
        #region Editor
        [SerializeField] private int _sceneIndex = 1;
        #endregion


        #region Initiate
        private void Awake()
        {
            PlanetButtonsManufacturer.OnPlanetSelected += OnPlanetSelected;
        }

        private void OnDestroy()
        {
            PlanetButtonsManufacturer.OnPlanetSelected -= OnPlanetSelected;
        }
        #endregion


        private void OnPlanetSelected(PlanetSettings settings)
        {
            Session.Current.SetPlanetSettings(settings);
            SceneManager.LoadScene(_sceneIndex, LoadSceneMode.Single);
        }
    }
}