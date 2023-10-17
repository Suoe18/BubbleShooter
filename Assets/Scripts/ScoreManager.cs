using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MegaCat
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] TMP_Text scoreText;

        public void UpdateScore()
        {
            scoreText.text = Score.GetInstance().PlayerScore.ToString(); 
        }
    }
}
