using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MegaCat
{
    public class CharacterSelector : MonoBehaviour
    {              
        public void SelectTactician()
        {
            Character.GetCharacterInstance().CharacterName = CharacterType.TACTICIAN;
        }

        public void SelectMiser()
        {
            Character.GetCharacterInstance().CharacterName = CharacterType.MISER;
        }

        public void Play()
        {
            SceneManager.LoadSceneAsync("STAGE SELECTOR");
        }
    }

}

