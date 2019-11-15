using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using BallOnPlanet.Data;


namespace BallOnPlanet.MainMenu
{
    public class PlanetButtonsManufacturer : MonoBehaviour
    {
        #region Editor
        [SerializeField] private GameObject _buttonPrefab;
        [SerializeField] private Transform _buttonsHolder;

        [SerializeField] private string _settingsPath = "Planet Settings";
        #endregion

        #region Private
        private PlanetSettings[] _planetSettingsList = null;
        private PlanetSettings[] PlanetSettingsList
        {
            get
            {
                if (_planetSettingsList == null || _planetSettingsList.Length == 0)
                    _planetSettingsList = Resources.LoadAll<PlanetSettings>(_settingsPath);

                return _planetSettingsList;
            }
        }

        public delegate void SelectPlanetAction(PlanetSettings settings);
        public static event SelectPlanetAction OnPlanetSelected;
        #endregion


        private void Awake()
        {
            CreatePlanetButtons();
        }

        private void CreatePlanetButtons()
        {
            foreach (var settings in PlanetSettingsList)
            {
                var buttonObject = Instantiate(_buttonPrefab, _buttonsHolder);
                var buttonElement = buttonObject.GetComponent<PlanetButtonElement>();

                if (buttonElement == null)
                    throw new System.ArgumentException($"Prefab must contain {nameof(PlanetButtonElement)}.");

                buttonElement.Fill(settings, () => OnPlanetSelected?.Invoke(settings));
            }
        }
    }
}