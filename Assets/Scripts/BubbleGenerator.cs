using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace MegaCat
{
    public class BubbleGenerator : MonoBehaviour
    {
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] Transform cannonShooter;

        [SerializeField] Sprite[] bubbleTypeSprite;

        [SerializeField] Image UINextBullet;

        private BubbleType bubbleLastType;

        private void Awake()
        {
            cannonShooter = GameObject.FindGameObjectWithTag("Bubble Position").transform;
        }

        public void InitFirstBullet()
        {            
            InitializeBubbleBullet(BubbleChecker.GetInstance().InitBullet());
            ShowNextBulletUI(BubbleChecker.GetInstance().NextBullet());
        }


        private void ShowNextBulletUI(BubbleType type)
        {
            UINextBullet.sprite = bubbleTypeSprite[(int)type];
            bubbleLastType = type;
        }

        public void InitializeNextBullet()
        {            
            GameObject bullet = Instantiate(bulletPrefab, cannonShooter.position, Quaternion.identity);
            bullet.GetComponent<SpriteRenderer>().sprite = UINextBullet.sprite;
            bullet.GetComponent<Bubble>().SetBubbleType(bubbleLastType);           
            ShowNextBulletUI(BubbleChecker.GetInstance().NextBullet());
        }

        private void InitializeBubbleBullet(BubbleType type)
        {
            GameObject bullet = Instantiate(bulletPrefab, cannonShooter.position, Quaternion.identity);
            bullet.GetComponent<SpriteRenderer>().sprite = bubbleTypeSprite[(int)type];
            bullet.GetComponent<Bubble>().SetBubbleType(type);
        }
    }
}
