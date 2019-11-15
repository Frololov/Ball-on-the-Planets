using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using BallOnPlanet.Data;


namespace BallOnPlanet.Data
{
    public class Session
    {
        #region Base
        private static readonly Session _current = new Session();
        public static Session Current => _current;

        public Session()
        {
            Load();
        }
        #endregion


        public PlanetSettings PlanetSettings { get; private set; }
        public UserProgress Progress { get; private set; }


        public void SetPlanetSettings(PlanetSettings planetSettings)
        {
            PlanetSettings = planetSettings;
        }

        public void Save()
        {
            Storage.Save<UserProgress>(Progress, nameof(Progress));
        }

        private void Load()
        {
            Progress = Storage.Load<UserProgress>(nameof(Progress));
        }
    }
}