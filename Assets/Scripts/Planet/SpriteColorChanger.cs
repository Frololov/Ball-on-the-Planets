using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using BallOnPlanet.Data;


namespace BallOnPlanet.Planet
{
    public class SpriteColorChanger : MonoBehaviour, IClickable
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;


        public void Click()
        {
            _spriteRenderer.color = Random.ColorHSV(0.0f, 1.0f, 0.6f, 0.8f, 0.6f, 0.7f);

            Session.Current.Progress.IncreaseClickCount();
        }
    }
}