using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            //should warn the player they were caught before restarting the level

            if (other.tag == "Player")
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
