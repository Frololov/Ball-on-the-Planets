using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using BallOnPlanet.Data;


namespace BallOnPlanet.MainMenu
{
    public class ClickCountUIVisualizer : MonoBehaviour
    {
        [SerializeField] private Text _textField;

        private void Awake()
        {
            var count = Session.Current.Progress.ClickCount;

            _textField.text = $"Clicked count: {count}";
        }
    }
}