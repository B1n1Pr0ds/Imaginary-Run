




using System;
using UnityEngine;

public class CarScript : MonoBehaviour
{
       
        [SerializeField] private float carSpeed;

        private PlayerScore ps;

   
        private void Update()
        {
                Move();
        }

        private void Move()
        {
                transform.position = new Vector3(transform.position.x - carSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        

        private void OnTriggerEnter2D(Collider2D other)
        {
                if (other.gameObject.tag == "EnemyDestroyerTag")
                {
                        Destroy(gameObject);
                }
            
                Debug.Log("collided " + other.gameObject.layer);
                
              
               
            
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
                if (other.gameObject.tag == "Player")
                {
                        ps = other.gameObject.GetComponent<PlayerScore>();
                        ps.Die();
                }
        }


        
}
