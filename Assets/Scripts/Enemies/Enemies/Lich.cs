using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lich : RangedEnemy
{
    protected override void Decide()
    {
        Attack();
        
    }
    protected override void Attack()
    {
        SpawnBullet(firingPoint.position, enemyTarget.position);
        base.Attack();
    }
    protected override void FlipSprite()
    {
        if(enemyTarget.transform.position.x > transform.position.x) enSprRenderer.flipX = false;
        else enSprRenderer.flipX = true;
    }
}
