using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MegaCat
{
    public class CannonMovementController : MonoBehaviour
    {
        [SerializeField] Camera mainCamera;
        [SerializeField] Transform cannonPosition;

        private void Start()
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }

        void Update()
        {
            RotateGun();
        }

        void RotateGun()
        {
            Vector2 distanceVector = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition) - (Vector2)cannonPosition.position;
            float targetAngle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;

            // Limit the rotation to 90 degrees to the left and right
            float maxRotation = 80.0f;
            targetAngle = Mathf.Clamp(targetAngle, -maxRotation, maxRotation);

            // To avoid sudden rotation: Adjust the rotation speed as needed
            float rotationSpeed = 12.0f; 
            Vector3 currentEulerAngles = transform.rotation.eulerAngles;

            currentEulerAngles.z = Mathf.LerpAngle(currentEulerAngles.z, targetAngle, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Euler(currentEulerAngles);
        }
    }

}
