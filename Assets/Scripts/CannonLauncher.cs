using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MegaCat
{
    public class CannonLauncher : MonoBehaviour
    {
        [SerializeField] public GameObject activeBullet;
        [SerializeField] Transform bulletInitialPosition;
        [SerializeField] Transform aimPosition;       
        [SerializeField] float shootForce;      

        private const string BULLET_TAG = "Bullet";
        private const string USED_BULLET_TAG = "LevelBubble";
        public bool didFire;

     
        private void Start()
        {
            StartCoroutine(InitCoroutine());
        }

        IEnumerator InitCoroutine()
        {
            yield return new WaitForSeconds(1);
            activeBullet = GameObject.FindGameObjectWithTag(BULLET_TAG);          
        }

        private void Update()
        {
            StartCoroutine(ShootCoroutine());
        }

        
        IEnumerator ShootCoroutine()
        {
            activeBullet = GameObject.FindGameObjectWithTag(BULLET_TAG);
            yield return new WaitUntil(() => activeBullet != null);            
            Rigidbody2D rb = activeBullet.GetComponent<Rigidbody2D>();
            if (Input.GetMouseButton(0) && activeBullet.GetComponent<Bullet>().isActive)
            {
                
                Vector3 direction = -(bulletInitialPosition.position - aimPosition.transform.position).normalized;
                rb.velocity = direction * shootForce;
                
                activeBullet.GetComponent<Bullet>().isActive = false;
                BubbleChecker.GetInstance().currentBubbleObject.Add(activeBullet);
                didFire = true;
            }                                  
            
        }

        public void ChangeBullet()
        {
            activeBullet.tag = USED_BULLET_TAG;
            activeBullet.GetComponent<Bullet>().onHitEvent = null;
            
        }

        
    }

}
