using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string enemyName;
    [SerializeField] private float moveSpeed;
    private float healthPoints;
    [SerializeField] private float maxHealthPoints;



    private Character player;
    private Transform targetPos;






    /////////////////////


    

    private void Start()
    {
        healthPoints = maxHealthPoints;
        
        player = FindObjectOfType<Character>();
        targetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
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
        Debug.Log(" " + enemyName + ", HP: " + healthPoints + ", Speed: " + moveSpeed);
    }

    protected virtual void Move()
    {
        
        //Debug.Log(Vector3.Distance( transform.position, targetPos.position));
        
        
        if(Vector3.Distance(transform.position, targetPos.position) > 0.9)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos.position, moveSpeed * Time.deltaTime);
        }
        
    }



    protected virtual void Attack()
    {
        
    }







    
    private void ReceiveDamage(float damage)
    {
        healthPoints -= damage;
    }
    
    private void Death()
    {

        ScoreManager.OnScoreChanged(5);

        Destroy(gameObject);
    }

    




    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "BaseBullet")
        {
            Destroy(coll.gameObject);
            
            ReceiveDamage(player.chDamage);
            

        }
    }
}
