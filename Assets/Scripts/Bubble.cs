using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.AddressableAssets.Build.Layout.BuildLayout;
using UnityEngine.UIElements;
using static UnityEngine.UI.CanvasScaler;

namespace MegaCat
{
    public class Bubble : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D bulletRigidbody;
        [SerializeField] public float radius;
        public BubbleType type;
        public bool isActive;
        public LayerMask bubbleLayer;

        public List<GameObject> matchingBubbles = new List<GameObject>();
        

        public void SetBubbleType(BubbleType type)
        {
            this.type = type;
        }

        public BubbleType GetBubbleType()
        {
            return type;
        }
        
      

        public void CheckAllAdjacentMatch(GameObject bubble)
        {
            int[] angles = { 0, 60, 120, 180, 240, 300 };
            foreach (int angle in angles)
            {
                GameObject adjacentBubble = GetAdjacentBubble(bubble, angle);
                if (adjacentBubble.GetComponent<Bubble>().type.Equals(this.gameObject.GetComponent<Bubble>().type))
                {
                    matchingBubbles.Add(adjacentBubble);
                    Debug.Log($"Match Type: {angle}");
                }
            }
        }

        public GameObject GetAdjacentBubble(GameObject bubble, float angle)
        {
            // Calculate the position of the adjacent bubble
            Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.up;
            Vector3 bubblePosition = bubble.transform.position + direction;
            Collider2D hit = Physics2D.OverlapCircle(bubblePosition, 0.1f);

            if (hit != null)
            {
                return hit.gameObject;
            }

            return null;
        }

    }
}
