
using System;
using UnityEngine;
using PlatformUtility = Unity.VisualScripting.PlatformUtility;

public class TruckScript : MonoBehaviour
{
    [SerializeField] private float truckSpeed;

    
    private PlayerScore ps;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = new Vector3(transform.position.x - truckSpeed * Time.deltaTime, transform.position.y, transform.position.z);
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
