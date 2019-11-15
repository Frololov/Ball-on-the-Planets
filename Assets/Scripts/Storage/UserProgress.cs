using System.Collections;
using System.Collections.Generic;

using UnityEngine;


namespace BallOnPlanet.Data
{
    [System.Serializable]
    public class UserProgress
    {
        public int ClickCount { get; private set; }


        public void IncreaseClickCount()
        {
            ClickCount++;
        }
    }
}