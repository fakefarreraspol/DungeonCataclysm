using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArcher : RangedEnemy
{
    
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
            else
            {
                Attack();
            }
        }
        
    }
    protected override void Attack()
    {
        
        base.Attack();
    }
    protected override void FlipSprite()
    {
        if (enemyTarget == null) return;
        if(enemyTarget.transform.position.x > transform.position.x) enSprRenderer.flipX = false;
        else enSprRenderer.flipX = true;
    }

    private void Shoot()
    {
        canMove = true;
        SpawnBullet(firingPoint.position, enemyTarget.position);
    }
}
