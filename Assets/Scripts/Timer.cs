using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MegaCat
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float initialTime = 60.0f;
        private float currentTime;
        private bool timerActive = true;

        [SerializeField] GameEvent gameOverEvent;
        [SerializeField] private TMP_Text timerText;

        private void Start()
        {
            currentTime = initialTime;
            UpdateTimerText();
        }

        private void Update()
        {
            if (timerActive)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerText();

                if (currentTime <= 0)
                {
                    OnTimerComplete();
                }
            }
        }

        private void UpdateTimerText()
        {
            if (timerText != null)
            {
                timerText.text = currentTime.ToString("F1");
            }
        }

        private void OnTimerComplete()
        {
            Debug.Log("Timer has reached 0!");
            timerActive = false;
            gameOverEvent?.Raise();
        }
    }
}
