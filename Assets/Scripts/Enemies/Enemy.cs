using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string enemyName;
    [SerializeField] private float moveSpeed;
    private int healthPoints;
    [SerializeField] private int maxHealthPoints;
    [SerializeField] protected int damage = 5;
    public float enemyRateOfFire;
    protected bool canAttack = true;
    private Character player;
    private Transform targetPos;



    


    /////////////////////
    private SpriteRenderer spriteRenderer;
    private Animator enAnimator;
    

    private void Start()
    {
        healthPoints = maxHealthPoints;
        
        player = FindObjectOfType<Character>();
        targetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spriteRenderer =  GetComponent<SpriteRenderer>();
        
        Introduction();
    }
    private void FixedUpdate()
    {
        Decisions();    
         Animate();
        
    }
    protected virtual void Introduction()
    {
        Debug.Log(" " + enemyName + ", HP: " + healthPoints + ", Speed: " + moveSpeed);
    }

    protected virtual void Decisions()
    {
        if(Vector3.Distance(transform.position, targetPos.position) > 0.9)
        {
            Move(targetPos);
        }
        else Attack();

    }
    protected virtual void Move(Transform pos)
    {     
        transform.position = Vector2.MoveTowards(transform.position, pos.position, moveSpeed * Time.deltaTime);
        
    }



    protected virtual void Attack()
    {
        
        Debug.Log("Attacked succesfull");
        if(canAttack)
        {
            DoDamage(damage);
            canAttack = false;
            Invoke("DelayBetweenAttacks", enemyRateOfFire);
        }
    }

    protected void DelayBetweenAttacks()
    {
        canAttack = true;
    }

    protected void DoDamage(int damage)
    {
        player.ReceiveDamage(damage);
    }

    private void ReceiveDamage(int damage)
    {
        healthPoints -= damage;

        // Destroy game object if enemy has no health
        if(healthPoints <= 0)
        {
            Death();
        }
    }
    
    private void Death()
    {

        ScoreManager.OnScoreChanged(5);

        Destroy(gameObject);
    }

    private void Animate()
    {
        FlipSprite();
    }
    
    private void FlipSprite()
    {
        if(targetPos.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else spriteRenderer.flipX = false;
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
