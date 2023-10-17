using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MegaCat
{
    public class BubbleGravity : MonoBehaviour
    {
        public LayerMask bubbleLayer;
        public float gravityForce = 10.0f;

        private void Start()
        {
            ApplyGravityToIsolatedBubbles();
        }

        void ApplyGravityToIsolatedBubbles()
        {
            // Get all bubbles in the scene
            GameObject[] bubbles = GameObject.FindGameObjectsWithTag("LevelBubble");

            foreach (GameObject bubble in bubbles)
            {
                // Check if the bubble has any neighbors of the same type
                if (!HasMatchingNeighbors(bubble))
                {
                    Rigidbody2D rb = bubble.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        // Apply gravity to make isolated bubbles fall
                        rb.AddForce(Vector2.down * gravityForce, ForceMode2D.Force);
                    }
                }
            }
        }

        bool HasMatchingNeighbors(GameObject bubble)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(bubble.transform.position, 0.1f, bubbleLayer);

            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject != bubble && collider.gameObject.CompareTag("LevelBubble") && collider.gameObject.GetComponent<Bubble>().type == bubble.GetComponent<Bubble>().type)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
