using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using BallOnPlanet.Data;


namespace BallOnPlanet.MainMenu
{
    public class AppDataSaver : MonoBehaviour
    {
        private static AppDataSaver Current = null;


        private void Awake()
        {
            if (Current != null)
            {
                Destroy(gameObject);
                return;
            }

            Current = this;
            transform.parent = null;

            DontDestroyOnLoad(gameObject);
        }


        private void OnApplicationFocus(bool focus)
        {
            if (focus == false)
                Session.Current.Save();
        }

        private void OnApplicationQuit()
        {
            Session.Current.Save();
        }
    }
}

