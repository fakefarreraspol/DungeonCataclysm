using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArcher : RangedEnemy
{
    
 protected override void Decide()
    {
        Attack();
        
    }
    protected override void Attack()
    {
        base.Attack();
    }
    protected override void FlipSprite()
    {
        if(enemyTarget.transform.position.x > transform.position.x) enSprRenderer.flipX = false;
        else enSprRenderer.flipX = true;
    }

    private void Shoot()
    {
        SpawnBullet(enemyTarget.position);
    }
}
