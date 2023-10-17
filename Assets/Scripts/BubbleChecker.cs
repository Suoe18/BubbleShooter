using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MegaCat
{
    public class BubbleChecker 
    {
        private static BubbleChecker instance;

        public static BubbleChecker GetInstance()
        {
            if(instance == null)
            {
                instance = new BubbleChecker();
            }
            return instance;
        }


        public List<BubbleType> currentBubbleTypes = new List<BubbleType>();
        public List<BubbleType> possibleBubbleType = new List<BubbleType>();

        public List<GameObject> currentBubbleObject = new List<GameObject>();


        public BubbleType InitBullet()
        {
            int random = Random.Range(0, possibleBubbleType.Count);
            return possibleBubbleType[random];
        }

        public BubbleType NextBullet()
        {
            int random = Random.Range(0, possibleBubbleType.Count);
            return possibleBubbleType[random];
        }

        private bool IsBubbleTypeActive(BubbleType bubbleType)
        {
            return currentBubbleTypes.Contains(bubbleType);
        }
        
        public void CheckRemainingBubbles()
        {
            foreach (var bubbleType in currentBubbleObject)
            {
                bool isActive = IsBubbleTypeActive(bubbleType.GetComponent<Bubble>().type);

                if (isActive && !possibleBubbleType.Contains(bubbleType.GetComponent<Bubble>().type))
                {
                    possibleBubbleType.Add(bubbleType.GetComponent<Bubble>().type);
                }
                else if (!isActive && possibleBubbleType.Contains(bubbleType.GetComponent<Bubble>().type))
                {
                    possibleBubbleType.Remove(bubbleType.GetComponent<Bubble>().type);
                }
            }
        }

        public void ClearData()
        {
            currentBubbleObject.Clear();
            currentBubbleTypes.Clear();
            possibleBubbleType.Clear();
        }
    }
}
