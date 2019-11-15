using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using BallOnPlanet.Data;


namespace BallOnPlanet.MainMenu
{
    public class PlanetButtonElement : MonoBehaviour
    {
        [SerializeField] private Text _textPlanetName;
        [SerializeField] private Button _buttonPlanetLoad;

        public void Fill(PlanetSettings settings, UnityAction clickAction)
        {
            name = settings.name;

            _textPlanetName.text = settings.Name;
            _buttonPlanetLoad.onClick.AddListener(clickAction);
        }
    }
}