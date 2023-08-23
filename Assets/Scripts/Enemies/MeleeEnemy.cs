using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    protected Transform attackingPoint;
    protected float enAttackArea;
    protected float enAttackRange;

    [SerializeField] private LayerMask enemyLayers;

    protected override void Start()
    {
        enAttackArea = enemyStats.EAttackArea;
        enAttackRange = enemyStats.EAttackRange;

        attackingPoint = gameObject.transform.Find("AttackingPoint");
        attackingPoint.position = transform.position;
        base.Start();
    }
    protected override void Decide()
    {
        if (enemyTarget == null) return;
        if (Vector2.Distance(transform.position, enemyTarget.position) < enChaseDistance)
        {
            if (Vector2.Distance(transform.position, enemyTarget.position) >= enAttackDistance)
            {
                SetPath(enemyTarget.position);
                Move();
            }
            else Attack();
        }

        if (canAttack) ComputeAttackingPoint();
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
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackingPoint.position, enAttackArea, enemyLayers);
        foreach (Collider2D enemy in hitPlayer)
        {
            Debug.Log("PlayerIsHit");
            DoDamage(enDamage);
        }

        canMove = true;
    }

    protected virtual void ComputeAttackingPoint()
    {
        if (enemyTarget == null) return;

        Vector2 test = enemyTarget.position - transform.position;
        //attackingPoint.position = ((Vector2)transform.position + test) * enAttackRange;
        attackingPoint.position = (Vector2)transform.position + (test.normalized * enAttackRange);
    }
}
