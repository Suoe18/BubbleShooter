using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MegaCat
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] GameObject[] BubbleLibrary;
        [SerializeField] Vector2 startPosition;
        [SerializeField] float bubbleRadius = 1.0f;
        [SerializeField] int rows = 5;
        [SerializeField] int columns = 7;
        [SerializeField] GameEvent onFinishLevelSetUp;

        private float hexWidth;
        private float hexHeight;

        void Start()
        {
            InitLevel();
        }

        private void InitLevel()
        {
            hexWidth = bubbleRadius * Mathf.Sqrt(3f);
            hexHeight = bubbleRadius * 1.5f;
            GenerateLevel();
        }

        private void GenerateLevel()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    int randomizer = Random.Range(0, 6);
                    Vector3 position = CalculateHexagonalPosition(startPosition, row, col);
                    GameObject bubble = Instantiate(BubbleLibrary[randomizer], position, Quaternion.identity);
                    BubbleChecker.GetInstance().currentBubbleObject.Add(bubble);
                    bubble.transform.parent = transform;

                    if (!BubbleChecker.GetInstance().currentBubbleTypes.Contains(bubble.GetComponent<Bubble>().type))
                    {
                        BubbleChecker.GetInstance().currentBubbleTypes.Add(bubble.GetComponent<Bubble>().type);
                    }
                }
            }

            BubbleChecker.GetInstance().CheckRemainingBubbles();
            onFinishLevelSetUp?.Raise();
        }

        Vector3 CalculateHexagonalPosition(Vector3 start, int row, int col)
        {
            float x = col * hexWidth;
            float y = row * hexHeight;

            if (col % 2 == 1)
            {
                y -= hexHeight * 0.5f;
            }

            return start + new Vector3(x, y, 0);
        }

        public void UpdateBubblePositions()
        {
            foreach (GameObject bubble in BubbleChecker.GetInstance().currentBubbleObject)
            {
                Vector3 snappedPosition = SnapToHexagonalGrid(bubble.transform.position);
                bubble.transform.position = snappedPosition;
            }
        }

        Vector3 SnapToHexagonalGrid(Vector3 position)
        {           
            float x = Mathf.Round(position.x / hexWidth) * hexWidth;
            float y = Mathf.Round(position.y / hexHeight) * hexHeight;

            return new Vector3(x, y, 0);
        }

        public void ClearLevel()
        {
            foreach (GameObject bubble in BubbleChecker.GetInstance().currentBubbleObject)
            {
                Destroy(bubble.gameObject);
            }
        }

        public void CheckColorAvailable()
        {
            BubbleChecker.GetInstance().CheckRemainingBubbles();

            Debug.Log("Possible Colors: " + BubbleChecker.GetInstance().possibleBubbleType.Count);
        }
    }
}
