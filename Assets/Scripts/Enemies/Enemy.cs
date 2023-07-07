using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string enemyName;
    [SerializeField] private float moveSpeed;
    private float healthPoints;
    [SerializeField] private float maxHealthPoints;



    private Transform target;

    private void Start()
    {
        healthPoints = maxHealthPoints;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        Introduction();
    }
    private void FixedUpdate()
    {
        Move();

        // Destroy game object if enemy has no health
        if(healthPoints <= 0)
        {
            Death();
        }
    }
    protected virtual void Introduction()
    {
        Debug.Log("My Name Is " + enemyName + ", HP: " + healthPoints + ", Speed: " + moveSpeed);
    }

    protected virtual void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    
    private void ReceiveDamage(int damage)
    {
        healthPoints -= damage;
    }
    
    private void Death()
    {
        Destroy(gameObject);
    }

    




    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "BaseBullet")
        {
            Destroy(coll.gameObject);
            ReceiveDamage(20);
        }
    }
}
