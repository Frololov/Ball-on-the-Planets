using System.Collections;
using System.Collections.Generic;

using UnityEngine;


namespace BallOnPlanet.Data
{
    [CreateAssetMenu(fileName = "New PlanetSettings", menuName = "Scriptable Data/Planet Settings")]
    public class PlanetSettings : ScriptableObject
    {
        [SerializeField] private float _gravity;
        [SerializeField] private Color _skyColor;

        public string Name => name;
        public float Gravity => _gravity;
        public Color SkyColor => _skyColor;
    }
}