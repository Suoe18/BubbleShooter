using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MegaCat
{
    public class Score
    {
        private static Score instance;

        public static Score GetInstance()
        {
            if(instance == null)
            {
                instance = new Score();
            }
            return instance;
        }

        private float playerScore;

        public float PlayerScore { get => playerScore; set => playerScore = value; }
    }
}
