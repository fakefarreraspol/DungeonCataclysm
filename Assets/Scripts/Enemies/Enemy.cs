using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Pathfinding;
using UnityEditor.Experimental.GraphView;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] protected EnemyStats enemyStats;
    protected string enName;
    protected int enMaxHealthPoints;
    private int enHealthPoints;
    protected float enSpeed;
    protected float enNextWaypointDistance;
    protected float enChaseDistance;
    protected float enAttackDistance;
    protected float enRateOfFire;
    protected int enDamage;
    protected float enCooldown;

    private float enDeathTime = 1;

    [Header("Behavior Control")]
    protected bool canAttack = true;
    [SerializeField] protected bool canMove = true;

    [Header("Pathfinding")]
    protected Path path;
    protected int currentWaypoint = 0;
    protected bool reachedEndOfPath = false;
    protected Seeker seeker;
    private bool canPathBeChanged = true;

    [Header("Utils")]
    protected Transform enemyTarget;
    // References to other Scripts/ Utils
    protected Character playerCharacter;
    protected Rigidbody2D enRb;
    protected Animator enAnimator;
    protected SpriteRenderer enSprRenderer;
    protected bool enIsAttacking = false;
    private bool enIsDead = false;
    protected bool isAbilityAvailable = true;

    private void Awake()
    {
        playerCharacter = FindObjectOfType<Character>();
        enemyTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        enSprRenderer = GetComponent<SpriteRenderer>();
        enAnimator = GetComponent<Animator>();

        seeker = GetComponent<Seeker>();
        enRb = GetComponent<Rigidbody2D>();
    }
    protected virtual void Start()
    {
        enName = enemyStats.EName;
        enMaxHealthPoints = enemyStats.EHealth;
        enSpeed = enemyStats.ESpeed;
        enChaseDistance = enemyStats.EChaseDistance;
        enAttackDistance = enemyStats.EAttackDistance;
        enRateOfFire = enemyStats.ERateOfFire;
        enDamage = enemyStats.EDamage;
        enNextWaypointDistance = enemyStats.ENextWaypointDistance;
        enCooldown = enemyStats.ECooldown;

        enHealthPoints = enMaxHealthPoints;



        Debug.Log("A " + enName + " has spawned!");

    }

    private void FixedUpdate()
    {
        if (enIsDead) return;
        Decide();
        Animate();

    }
    protected virtual void Decide()
    {


    }


    protected void Move()
    {
        if (!canMove) return;

        if (path == null) return;
        else if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else reachedEndOfPath = false;

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - enRb.position).normalized;


        enRb.AddForce(direction * enSpeed);

        float distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if (distance < enNextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    protected void SetPath(Vector2 destPos)
    {
        if (canPathBeChanged)
        {
            seeker.StartPath(transform.position, destPos, OnPathComplete);
            canPathBeChanged = false;
            Invoke("changePathStatus", 0.5f);
        }
    }
    private void changePathStatus() { canPathBeChanged = true; }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }

    }

    private void Animate()
    {
        //Debug.Log(enRb.velocity.x);
        if (enRb.velocity.x > 0.1f || enRb.velocity.x < -0.1f || enRb.velocity.y < -0.1f || enRb.velocity.y > 0.1f) enAnimator.SetBool("isWalking", true);
        else enAnimator.SetBool("isWalking", false);


        FlipSprite();
    }
    protected virtual void FlipSprite()
    {
        if (enRb.velocity.x > 0)
            enSprRenderer.flipX = false;
        else if (enRb.velocity.x < 0) enSprRenderer.flipX = true;
    }

    protected virtual void Attack()
    {
        if (canAttack)
        {
            canMove = false;
            enAnimator.SetTrigger("Attack");
            canAttack = false;
            Invoke("ResetAttack", enRateOfFire);
        }
    }

    private void ResetAttack() { canAttack = true; }




    private void ReceiveDamage(int damage)
    {
        enHealthPoints -= damage;
        if (enHealthPoints <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(enRb);
        Destroy(gameObject.GetComponent<BoxCollider2D>());

        enSprRenderer.renderingLayerMask = 4;

        enIsDead = true;
        enAnimator.SetTrigger("Death");

        Destroy(gameObject, enDeathTime);
    }


    protected IEnumerator StartEnemyAbilityCooldown()
    {
        isAbilityAvailable = false;

        yield return new WaitForSeconds(enCooldown);

        isAbilityAvailable = true;
    }





    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "BaseBullet")
        {
            Destroy(coll.gameObject);

            ReceiveDamage(playerCharacter.GetCharacterDamage());
        }
    }

    protected Vector2 ComputeVector(Vector2 a, Vector2 b)
    {
        return new Vector2(b.x - a.x, b.y - a.y);
    }
}
