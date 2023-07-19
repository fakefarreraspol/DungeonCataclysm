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
    protected bool isAttacking = false;
    private Character player;
    protected Transform targetPos;


    [SerializeField] protected float distanceFromPlayer;

    protected bool isMoving = false;



    /////////////////////
    private SpriteRenderer spriteRenderer;
    private Animator enAnimator;


    private void Start()
    {
        healthPoints = maxHealthPoints;

        player = FindObjectOfType<Character>();
        targetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enAnimator = GetComponent<Animator>();

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
        if (Vector3.Distance(transform.position, targetPos.position) > distanceFromPlayer)
        {
            isMoving = true;
            Move(targetPos);
        }
        else
        {
            Attack();
            isMoving = false;
        }

    }
    protected virtual void Move(Transform pos)
    {
        transform.position = Vector2.MoveTowards(transform.position, pos.position, moveSpeed * Time.deltaTime);

    }



    protected virtual void Attack()
    {


        if (canAttack)
        {
            enAnimator.SetTrigger("Attack");
            Debug.Log("Attacked succesfull");
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
        if (healthPoints <= 0)
        {
            Death();
        }
    }

    private void Death()
    {

        ScoreManager.OnScoreChanged(1);

        Destroy(gameObject);
    }

    ////////////////////////////////////// ANIMATIONS ///////////////////////////////////////
    protected virtual void Animate()
    {
        if (isMoving)
            enAnimator.SetBool("isWalking", true);
        else
            enAnimator.SetBool("isWalking", false);

        FlipSprite();
    }

    private void FlipSprite()
    {
        if (targetPos.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else spriteRenderer.flipX = false;
    }

    protected bool AnimatorIsPlaying(string stateName)
    {
        return AnimatorIsPlaying() && enAnimator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
    private bool AnimatorIsPlaying()
    {
        return enAnimator.GetCurrentAnimatorStateInfo(0).length >
               enAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "BaseBullet")
        {
            Destroy(coll.gameObject);

            ReceiveDamage(player.chDamage);


        }
    }




    protected Vector2 ComputeVector(Vector2 a, Vector2 b)
    {
        return new Vector2(b.x - a.x, b.y - a.y);
    }
}
