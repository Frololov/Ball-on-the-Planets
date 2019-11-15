using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using BallOnPlanet.Data;


namespace BallOnPlanet.Planet
{
    public class PlanetInitializer : MonoBehaviour
    {
        [SerializeField] private Camera _cameraMain;
        [SerializeField] private Rigidbody2D _ballRigidbody;



        private void Awake()
        {
            var settings = Session.Current.PlanetSettings;
            if (settings == null)
                return;

            SetBackgroud(settings.SkyColor);
            SetGravity(settings.Gravity);
        }

        private void SetBackgroud(Color color)
        {
            _cameraMain.backgroundColor = color;
        }

        private void SetGravity(float value)
        {
            _ballRigidbody.gravityScale = value / 10;
        }
    }
}