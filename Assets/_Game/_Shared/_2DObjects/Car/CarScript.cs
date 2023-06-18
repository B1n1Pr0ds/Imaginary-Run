

using System;
using UnityEngine;

public class CarScript : MonoBehaviour
{
        [SerializeField] private float carSpeed;
        [SerializeField] private LayerMask enemyDestroyerLayer;
        private void Update()
        {
                transform.position = new Vector3(transform.position.x-carSpeed, transform.position.y, transform.position.z);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == enemyDestroyerLayer) ;
            {
                Debug.Log("Collided");
            }
        }
}
