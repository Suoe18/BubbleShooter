using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

namespace MegaCat
{
    public class DangerLine : MonoBehaviour
    {        
        [SerializeField] GameEvent gameOverEvent;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Ceilling") || collision.CompareTag("LevelBubble"))
            {                
                Destroy(collision.gameObject);                                
                gameOverEvent?.Raise();
            }
        }
    }
}
