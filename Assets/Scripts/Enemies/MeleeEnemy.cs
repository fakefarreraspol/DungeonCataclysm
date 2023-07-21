using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
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
    }

    protected override void Attack()
    {
        Debug.Log("Attacked");        
        base.Attack();
    }

    protected virtual void DoDamage(int damage)
    {
        playerCharacter.ReceiveDamage(damage);
    }
}
