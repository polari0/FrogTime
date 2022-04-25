using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FrogTime
{
    internal class DeathMessageUIButtons : MonoBehaviour
    {
        public void QuiteGame()
        {
            Application.Quit();
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    } 
}
