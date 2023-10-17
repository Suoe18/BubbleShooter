using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MegaCat
{
    public class LevelGameHandler : MonoBehaviour
    {        
        public void RetryGame()
        {
            BubbleChecker.GetInstance().ClearData();
            SceneManager.LoadSceneAsync("ICE CAVE");
        }

        public void CharacterSelect()
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
