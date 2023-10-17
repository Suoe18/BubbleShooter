using System.Collections;
using System.Collections.Generic;


namespace MegaCat
{
    public class Character
    {
        private static Character instance;

        public static Character GetCharacterInstance()
        {
            if(instance == null)
            {
                instance = new Character();
            }
            return instance;
        }

        private CharacterType characterName;

        public CharacterType CharacterName { get => characterName; set => characterName = value; }
    }
   
}
