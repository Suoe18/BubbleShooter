using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MegaCat
{
    public class MainMenu : MonoBehaviour
    {
        public void NewGame()
        {
            BubbleChecker.GetInstance().ClearData();           
            SceneManager.LoadSceneAsync("CHARACTER SELECTOR");
        }

        public void ExitGame()
        {
            BubbleChecker.GetInstance().ClearData();
            Application.Quit();
        }
    }
}
