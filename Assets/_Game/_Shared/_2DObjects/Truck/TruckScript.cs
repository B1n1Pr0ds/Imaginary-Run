
using System;
using UnityEngine;

public class TruckScript : MonoBehaviour
{
    [SerializeField] private float truckSpeed;


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
            
        Debug.Log("collided" + other.gameObject.layer);


      
    }
    
}
