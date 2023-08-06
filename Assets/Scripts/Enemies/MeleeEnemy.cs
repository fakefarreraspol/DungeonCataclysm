using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    protected Transform attackingPoint;
    [SerializeField] protected float attackRange;
    [SerializeField] protected Vector2 APOffset;

    [SerializeField] private LayerMask enemyLayers;

    protected override void Start()
    {
        attackingPoint = gameObject.transform.Find("AttackingPoint");
        attackingPoint.transform.position = new Vector2(transform.position.x, transform.position.y) + APOffset;
        base.Start();
    }
    protected override void Decide()
    {
        if (Vector2.Distance(transform.position, enemyTarget.position) < chaseDistance)
        {
            if (Vector2.Distance(transform.position, enemyTarget.position) >= attackDistance)
            {
                SetPath(enemyTarget.position);
                Move();
            }
            else Attack();
        }

        FlipAttackingPoint();
    }

    protected override void Attack()
    {
        base.Attack();
    }

    protected virtual void DoDamage(int damage)
    {
        playerCharacter.ReceiveDamage(damage);
    }

    protected void IsPlayerHit()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackingPoint.position, attackRange, enemyLayers);
        
        foreach(Collider2D enemy in hitPlayer)
        {
            Debug.Log("PlayerIsHit");
            DoDamage(enDamage);
        }
    }

    protected virtual void FlipAttackingPoint()
    {
        if (enSprRenderer.flipX) attackingPoint.transform.position = (Vector2)transform.position + new Vector2 (-APOffset.x, -APOffset.y);
        else attackingPoint.transform.position = (Vector2)transform.position + new Vector2 (APOffset.x, -APOffset.y);
    }
}
