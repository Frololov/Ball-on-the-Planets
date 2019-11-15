using System.Collections;
using System.Collections.Generic;

using UnityEngine;


namespace BallOnPlanet.Planet
{
    public class ColliderClicker : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var clickable = collision.transform.GetComponent<IClickable>();
            if (clickable != null)
                clickable.Click();
        }
    }
}