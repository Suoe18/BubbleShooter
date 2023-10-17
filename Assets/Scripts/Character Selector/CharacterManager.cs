using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MegaCat
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField] Vector2 startingPoint;
        [SerializeField] GameObject[] characters;

        GameObject activeCharacter;

        private void OnEnable()
        {
            InitializeCharacter();
        }
       

        void InitializeCharacter()
        {
            if(Character.GetCharacterInstance().CharacterName.Equals(CharacterType.TACTICIAN))
            {
                GameObject newCharacter = Instantiate(characters[0], startingPoint, Quaternion.identity);
                activeCharacter = newCharacter;
            }
            else if(Character.GetCharacterInstance().CharacterName.Equals(CharacterType.MISER))
            {
                GameObject newCharacter = Instantiate(characters[1], startingPoint, Quaternion.identity);
                activeCharacter = newCharacter;
            }

            
        }

        public void DisableCharacter()
        {           
            Destroy(activeCharacter);
        }

    }
}
