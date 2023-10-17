using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace MegaCat
{
    public class Bullet : Bubble
    {
        public Transform targetToFollow;
        private bool isFollowing = true;        
        public const string BUBBLE_POSITION = "Bubble Position";
       
        public int minMatches = 3; 

        [SerializeField] public GameEvent onHitEvent;
        [SerializeField] public GameEvent onScoreUpdateEvent;
        [SerializeField] public GameEvent onVictoryEvent;


        private void Start()
        {
            isActive = true;
            targetToFollow = GameObject.FindGameObjectWithTag(BUBBLE_POSITION).transform;
        }

        void Update()
        {
            FollowCannon();
            
        }

        private void FollowCannon()
        {
            if(isActive) 
            {
                if (isFollowing && targetToFollow != null)
                {                    
                    transform.position = targetToFollow.position;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    isFollowing = false;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.collider.CompareTag("Ceilling"))
            {
                bulletRigidbody.velocity = Vector2.zero;                
                onHitEvent?.Raise();               
            } 
            else if(collision.collider.CompareTag("LevelBubble"))
            {
                bulletRigidbody.velocity = Vector2.zero;
                CheckForMatches(transform.position, collision.collider.gameObject.GetComponent<Bubble>().type);
                onHitEvent?.Raise();
            }
        }


        
        public void CheckForMatches(Vector2 shootPosition, BubbleType type)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(shootPosition, 1f, bubbleLayer);
            List<GameObject> matchingBubbles = new List<GameObject>();

            foreach (Collider2D collider in colliders)
            {
                Bubble bubble = collider.GetComponent<Bubble>();
                if (bubble != null && bubble.type == type)
                {
                    matchingBubbles.Add(collider.gameObject);
                    Debug.Log("COUNTED: " + matchingBubbles.Count);
                }
            }

            if (matchingBubbles.Count >= minMatches)
            {              
                foreach (GameObject bubble in matchingBubbles)
                {                                        
                    Score.GetInstance().PlayerScore += 3;
                    onScoreUpdateEvent?.Raise();
                    CheckCondition();
                    PopBubble(bubble);
                }
            }
       }               
       
        void PopBubble(GameObject bubble)
        {            
            if(BubbleChecker.GetInstance().currentBubbleObject.Contains(bubble))
            {
                BubbleChecker.GetInstance().currentBubbleObject.Remove(bubble);
            }            
            Destroy(bubble);
        }

        

        public void CheckCondition()
        {
            if (BubbleChecker.GetInstance().currentBubbleObject.Count <= 1)
            {
                onVictoryEvent?.Raise();
            }
        }
    }
}
